using AutoMapper;
using Africanbiomedtests.Entities;
using Africanbiomedtests.Models.Accounts;
using Africanbiomedtests.Models.Newborns;
using Africanbiomedtests.Models.MedTests;
using Africanbiomedtests.Models.MedTestsOrder;
using Africanbiomedtests.Models.MedTestsResults;

namespace Africanbiomedtests.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>();

            CreateMap<Account, AuthenticateResponse>();

            CreateMap<RegisterRequest, Account>();

            CreateMap<CreateRequest, Account>();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

        //Mapping HealthcareProvider
            CreateMap<HealthcareProvider, HealthcareProviderAccountResponse>();

            CreateMap<HealthcareProvider, AuthenticateResponse>();

            CreateMap<HealthcareProviderRegisterRequest, HealthcareProvider>();

            CreateMap<HealthcareProviderCreateRequest, HealthcareProvider>();

            CreateMap<HealthcareProviderUpdateRequest, HealthcareProvider>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

        //Mapping Newborn model to entity objects
            CreateMap<Newborn, NewbornAccountResponse>();
                    
            CreateMap<NewbornCreateRequest, Newborn>();

            CreateMap<NewbornUpdateRequest, Newborn>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        //if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));


                    //Mapping MedTest model to entity objects
            CreateMap<MedTest, MedTestsAccountResponse>();
                    
            CreateMap<MedTestsCreateRequest, MedTest>();

            CreateMap<MedTestsUpdateRequest, MedTest>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        //if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

                    //Mapping MedTestOrder model to entity objects
            CreateMap<MedTestOrder, MedTestsOrderResponse>();
                    
            CreateMap<MedTestsCreateRequest, MedTestOrder>();

            CreateMap<MedTestsUpdateRequest, MedTestOrder>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        //if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

                    //Mapping MedTestResult model to entity objects
            CreateMap<MedTestResult, MedTestsResultResponse>();
                    
            CreateMap<MedTestsCreateRequest, MedTestResult>();

            CreateMap<MedTestsUpdateRequest, MedTestResult>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        //if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));
        }
    }
}