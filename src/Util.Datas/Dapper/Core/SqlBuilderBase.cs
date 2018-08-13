﻿using System.Collections.Generic;
using Util.Datas.Matedatas;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Datas.Dapper.Core {
    /// <summary>
    /// Sql生成器
    /// </summary>
    public abstract class SqlBuilderBase : Sql.Queries.Builders.Core.SqlBuilderBase {
        /// <summary>
        /// 跟踪日志名称
        /// </summary>
        public const string TraceLogName = "SqlQueryLog";

        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        protected SqlBuilderBase( IEntityMatedata matedata = null ) : base( matedata ) {
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        protected override void WriteTraceLog( string sql, IDictionary<string, object> parameters ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( "SqlQuery查询调试:" )
                .Sql( sql )
                .SqlParams( parameters )
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog() {
            try {
                return Log.GetLog( TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }
    }
}
