using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Utilities.CalmQuery
{
    public static class HrView
    {
        public static class GetHr
        {
            public const string GetByCompanyEmail = @"<View><Query>
                                                         <Where>
                                                            <Eq>
                                                               <FieldRef Name='CompanyEmail' />
                                                               <Value Type='Text'>{0}</Value>
                                                            </Eq>
                                                         </Where>
                                                      </Query></View>";
        }
    }
}