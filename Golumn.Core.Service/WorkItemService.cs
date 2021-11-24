using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using PR.Ado.Core.Data;
using PR.Ado.Core.Domain;

namespace PR.Ado.Core.Service
{
    public class ReportService
    {
        private readonly TfsApiContext ctx;

        public ReportService()
        {
            ctx = new TfsApiContext();
        }

        

    }
}
