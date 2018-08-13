﻿using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Dapper.SqlServer {
    /// <summary>
    /// Sql Server方言
    /// </summary>
    public class SqlServerDialect : IDialect {
        /// <summary>
        /// 获取安全名称
        /// </summary>
        public string SafeName( string name ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return string.Empty;
            if( name == "*" )
                return name;
            name = name.Trim().TrimStart( '[' ).TrimEnd( ']' );
            return $"[{name}]";
        }
    }
}
