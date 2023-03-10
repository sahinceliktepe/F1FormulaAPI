public class RaceResult
{
    public MRDataTemplate MRData { get; set; }

    public class MRDataTemplate
    {
        public RaceTableTemplate RaceTable { get; set; }

        public class RaceTableTemplate
        {
            public string season { get; set; }
            public string round { get; set; }

            public RacesTemplate[] Races { get; set; }

            public class RacesTemplate
            {
                public string season { get; set; }
                public string round { get; set; }

                public ResultsTemplate[] Results { get; set; }

                public class ResultsTemplate
                {
                    public string number { get; set; }
                    public string position { get; set; }
                    public string points { get; set; }

                    public DriverTemplate Driver { get; set; }
                    public ConstructorTemplate Constructor { get; set; }

                    public class DriverTemplate
                    {
                        public string givenName { get; set; }
                        public string familyName { get; set; }
                    }

                    public class ConstructorTemplate
                    {
                        public string name { get; set; }
                    }

                    public string grid { get; set; }
                    public string laps { get; set; }
                    public string status { get; set; }

                    public TimeTemplate Time { get; set; }

                    public class TimeTemplate
                    {
                        public string time { get; set; }
                    }
                }
            }
        }
    }
}



