using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Enums;
using CQL.Interfaces;
using CQL.Models;
using Data.Enums;
using Data.Interfaces;
using Data.Sources;

namespace CQL.Visitors
{
    public class SourceVisitor : CQLBaseVisitor<ISource>
    {
        public override ISource VisitSession(CQLParser.SessionContext context)
        {
            Season season = (Season)Enum.Parse(typeof(Season), context.Season().GetText(), true);
            int year = int.Parse(context.Year().ToString());
            return new SessionApi(season, year);
        }

        public override ISource VisitCatalog(CQLParser.CatalogContext context)
        {
            int startYear = int.Parse(context.Year().First().ToString());
            return new CatalogApi(startYear);
        }
    }
}
