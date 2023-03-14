using System.Collections;
using System.Collections.Generic;
using WebAppPractice2023.Data.Interfaces;
using WebAppPractice2023.Data.Models;

namespace WebAppPractice2023.Data.Mocks
{
    public class MockTenants : ITenants
    {
        IEnumerable<Tenants> ITenants.GetAllTenants
        {
            get
            {
                return new List<Tenants>
                {
                    new Tenants
                    { 
                        Id = 001,
                        Surname = "Иванов",
                        Name = "Иван",
                        Patronymic = "Иванович",
                        PhoneNumber = "+1234567890",
                        Email = "te.st@gmail.com"
                    },
                    new Tenants 
                    {
                        Id = 002,
                        Surname = "Олегов",
                        Name = "Олег",
                        Patronymic = "Олегович",
                        PhoneNumber = "+0987654321",
                        Email = "te.st@mail.ru"
                    },
                    new Tenants
                    {
                        Id = 003,
                        Surname = "Акимов",
                        Name = "Аким",
                        Patronymic = "Акимович",
                        PhoneNumber = "+1122334455",
                        Email = "te.st@yandex.ru"
                    }
                };
            }
        }

        public IEnumerable<Tenants> Tenant { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Tenants GetTenants(int tenantId)
        {
            throw new System.NotImplementedException();
        }
    }
}
