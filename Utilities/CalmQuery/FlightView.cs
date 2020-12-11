using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Utilities.CalmQuery
{
    public static class FlightView
    {
        public static class FlightSchedules
        {
            public const string GetByFlightDate = @"<View><Query>
                                                       <Where>
                                                          <Eq>
                                                             <FieldRef Name='FlightDate' />
                                                             <Value IncludeTimeValue='FALSE' Type='DateTime'>{0}</Value>
                                                          </Eq>
                                                       </Where>
                                                    </Query></View>";
            public const string GetByFlightDateAndFlightNumber = @"<View><Query>
                                                                      <Where>
                                                                         <And>
                                                                            <Geq>
                                                                               <FieldRef Name='FlightDate' />
                                                                               <Value IncludeTimeValue='FALSE' Type='DateTime'>{0}</Value>
                                                                            </Geq>
                                                                            <Eq>
                                                                               <FieldRef Name='FlightNumber' />
                                                                               <Value Type='Text'>{1}</Value>
                                                                            </Eq>
                                                                         </And>
                                                                      </Where>
                                                                   </Query></View>";
        }

        public static class FlightMembers
        {
            public const string GetByFlightDateAndFlightNumber = @"<View><Query>
                                                                      <Where>
                                                                         <And>
                                                                            <Eq>
                                                                               <FieldRef Name='FlightDate' />
                                                                               <Value IncludeTimeValue='FALSE' Type='DateTime'>{0}</Value>
                                                                            </Eq>
                                                                            <Eq>
                                                                               <FieldRef Name='FlightNumber' />
                                                                               <Value Type='Number'>{1}</Value>
                                                                            </Eq>
                                                                         </And>
                                                                      </Where>
                                                                   </Query></View>";

            public const string GetByFlightDateAndFlightNumberPassenger = @"<View><Query>
                                                                              <Where>
                                                                                <And>
                                                                                <Eq>
                                                                                   <FieldRef Name='FlightDate' />
                                                                                   <Value IncludeTimeValue='FALSE' Type='DateTime'>{0}</Value>
                                                                                </Eq>
                                                                                      <Eq>
                                                                                         <FieldRef Name='FlightNumber' />
                                                                                         <Value Type='Number'>{1}</Value>
                                                                                      </Eq>
                                                                                </And>
                                                                               </Where>
                                                                            </Query></View>";

        }
    }
}