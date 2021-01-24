namespace ContactManagement.Data
{
    public static class DataSeeder
    {
        public static void Seed(this ContactDbContext dbContext)
        {
            dbContext.ContactNumberType.AddRange(
                new Entity.ContactNumberType { Id = 1, NumberType = "Home" },
                new Entity.ContactNumberType { Id = 2, NumberType = "Mobile" },
                new Entity.ContactNumberType { Id = 3, NumberType = "Work" },
                new Entity.ContactNumberType { Id = 4, NumberType = "Secondary" }
            );

            dbContext.ContactStatus.AddRange(
                new Entity.ContactStatus { Id = 1, Status = "Active"},
                new Entity.ContactStatus { Id = 2, Status = "Active"}
            );

            dbContext.Contact.AddRange(
                new Entity.Contact { Id = 1, FirstName = "Abc",  },
                new Entity.Contact { Id = 2, FirstName = "Pqr" },
                new Entity.Contact { Id = 3, FirstName = "Xyz" }
            );

            dbContext.ContactNumbers.AddRange(
                new Entity.ContactNumber { ContactId = 1, Number = "1111111111", NumberType = 1 },
                new Entity.ContactNumber { ContactId = 1, Number = "2222222222", NumberType = 2 },
                new Entity.ContactNumber { ContactId = 2, Number = "3333333333", NumberType = 3 },
                new Entity.ContactNumber { ContactId = 2, Number = "4444444444", NumberType = 4 },
                new Entity.ContactNumber { ContactId = 3, Number = "5555555555", NumberType = 2 },
                new Entity.ContactNumber { ContactId = 3, Number = "6666666666", NumberType = 3 }
            );

            dbContext.SaveChanges();
        }
    }
}
