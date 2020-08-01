        public static MoDtoVar GivenTheDefaultMoDtoVar()
        {
            var response = new MoDtoVar()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<MoDtoVar> GivenTheDefaultListMoDtoVar()
        {
            var dto1 = GivenTheDefaultMoDtoVar();
            dto1.Id = 1;

            var dto2 = GivenTheDefaultMoDtoVar();
            dto2.Id = 2;

            var response = new List<MoDtoVar>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static MoResponseVar GivenTheDefaultMoResponseVar()
        {
            var response = new MoResponseVar()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<MoResponseVar> GivenTheDefaultListMoResponseVar()
        {
            var response1 = GivenTheDefaultMoResponseVar();
            response1.Id = 1;

            var response2 = GivenTheDefaultMoResponseVar();
            response2.Id = 2;

            var response = new List<MoResponseVar>()
            {
                response1,
                response2
            };

            return response;
        }

        public static MoRequestVar GivenTheDefaultMoRequestVar()
        {
            var response = new MoRequestVar()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static MoModelVar GivenTheDefaultMoModelVar()
        {
            var response = new MoModelVar()
            {
                Id = 1,
                Property0 = "Property",
                Property1 = "Property",
                Property2 = "Property",
                Property3 = "Property",
                Property4 = "Property",
                Property5 = "Property",
                Property6 = "Property",
                Property7 = "Property",
                Property8 = "Property",
                Property9 = "Property"
            };

            return response;
        }

        public static List<MoModelVar> GivenTheDefaultListMoModelVar()
        {
            var model1 = GivenTheDefaultMoModelVar();
            model1.Id = 1;

            var model2 = GivenTheDefaultMoModelVar();
            model2.Id = 2;

            var response = new List<MoModelVar>()
            {
                model1,
                model2
            };

            return response;
        }

        public static MoModelLogVar GivenTheDefaultMoModelLogVar()
        {
            var response = new MoModelLogVar()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousValue = "PreviousValue",
                NewValue = "NewValue",
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<MoModelLogVar> GivenTheDefaultListMoModelLogVar()
        {
            var entity = GivenTheDefaultMoModelVar();

            var model1 = GivenTheDefaultMoModelLogVar();
            model1.Id = 1;
            model1.PreviousValue = "null";
            model1.NewValue = JsonConvert.SerializeObject(entity);

            var model2 = GivenTheDefaultMoModelLogVar();
            model2.Id = 2;
            model2.PreviousValue = JsonConvert.SerializeObject(entity);
            model2.NewValue = "null";

            var response = new List<MoModelLogVar>()
            {
                model1,
                model2
            };

            return response;
        }

        public static MoModelLogDtoVar GivenTheDefaultMoModelLogDtoVar()
        {
            var response = new MoModelLogDtoVar()
            {
                Id = 1,
                Username = "Username",
                DateTime = DateTime,
                PreviousEntity = default,
                NewEntity = default,
            };

            return response;
        }

        public static List<MoModelLogDtoVar> GivenTheDefaultListMoModelLogDtoVar()
        {
            var dto = GivenTheDefaultMoDtoVar();

            var model1 = GivenTheDefaultMoModelLogDtoVar();
            model1.Id = 1;
            model1.PreviousEntity = null;
            model1.NewEntity = dto;

            var model2 = GivenTheDefaultMoModelLogDtoVar();
            model2.Id = 2;
            model2.PreviousEntity = dto;
            model2.NewEntity = null;

            var response = new List<MoModelLogDtoVar>()
            {
                model1,
                model2
            };

            return response;
        }