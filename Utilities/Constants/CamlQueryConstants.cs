using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirwayBE.API.Utilities.Constants
{
    public static class CamlQueryConstants
    {
        public const string LookupMultiFieldQuery = @"<Where>
                                                            <Contains>
                                                                <FieldRef Name=""{0}"" LookupId=""TRUE"" />
                                                                <Value Type=""LookupMulti"">{1}</Value>
                                                            </Contains>
                                                        </Where>";
        public const string OrderPatern = @"<OrderBy>
                                                <FieldRef Name='{0}' Ascending='{1}' />
                                            </OrderBy>";

        public const string ContainsQuery =
            @"<Where><Contains><FieldRef Name=""{0}""/><Value Type=""{1}"">{2}</Value></Contains></Where>";

        public const string EqualQuery =
            @"<Where><Eq><FieldRef Name=""{0}""/><Value Type=""{1}"">{2}</Value></Eq></Where>";

        public const string FiefdRef = @"<FieldRef Name=""{0}""/>";
        public const string LookupFieldQuery = @"<Where>
                                                    <Eq>
                                                        <FieldRef Name=""{0}"" LookupId=""TRUE"" />
                                                        <Value Type=""Lookup"">{1}</Value>
                                                    </Eq>
                                                </Where>";
        public const string IsNotNullQuery = @"<Where>
                                                    <IsNotNull>
                                                        <FieldRef Name=""{0}""/>
                                                    </IsNotNull>
                                                </Where>";
        public const string InTemplate = @"<In><FieldRef Name=""{0}"" />
                                           <Values>{1}</Values></In>";
        public const string EqTemplate = @"<Eq><FieldRef Name=""{0}""/><Value Type=""{1}"">{2}</Value></Eq>";
        public const string WhereTemplate = @"<Where>{0}</Where>";

        public const string SPTextType = "Text";
        public const string SPNumberType = "Number";
        public const string SPFalseValue = "False";
        public const string SPTrueValue = "True";
        public const string SPChoice = "Choice";
    }
}