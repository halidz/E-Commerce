
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Commerce.Core
{
    public class NhHelper : INhHelper
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;
        public NhHelper(IDictionary<string, string> configParameters, bool allowInstall, List<string> mappingFiles)
        {
            configParameters.ToList()
                .ForEach(x => Console.WriteLine("{0}:{1}", x.Key, x.Value));

            _configuration = new Configuration().DataBaseIntegration(
                x =>
                {
#if DEBUG
                    x.LogSqlInConsole = true;
                    x.LogFormattedSql = true;
#endif
                });


            var cfg = _configuration.SetProperties(configParameters);
            var modelMapper = new ModelMapper();
            mappingFiles.ToList().ForEach(
                assebmlyFile => modelMapper.AddMappings(Assembly.Load(assebmlyFile).GetExportedTypes()));

            var mp = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            // For Duplicate mapping
            mp.autoimport = false;
            cfg.AddDeserializedMapping(mp, null);

#pragma warning disable CS0618 // Type or member is obsolete
            SchemaMetadataUpdater.QuoteTableAndColumns(cfg);
#pragma warning restore CS0618 // Type or member is obsolete

            if (!Directory.Exists(ScriptFolder))
                Directory.CreateDirectory(ScriptFolder);

            if (allowInstall && !File.Exists(ScriptFile))
                new SchemaExport(cfg).SetOutputFile(ScriptFile).Create(false, true);
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory ?? (_sessionFactory = _configuration.BuildSessionFactory());
            }
        }

        private string ScriptFolder
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts");
            }
        }
        private string ScriptFile
        {
            get
            {
                return Path.Combine(ScriptFolder, "installed.sql");
            }
        }


        ISession _session;
        public ISession Session
        {
            get
            {
                return _session ?? (_session = SessionFactory.OpenSession());
            }
        }
    }

}