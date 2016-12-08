using DoubleBooking.Domain.Entities;

namespace DoubleBooking.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoubleBooking.Infrastructure.Data.DoubleBookingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DoubleBooking.Infrastructure.Data.DoubleBookingContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.LocalAuthorities.AddOrUpdate(x=>x.Id,
                new LocalAuthorities {LocalAuthoritiesName = "Adur"},
                new LocalAuthorities { LocalAuthoritiesName = "Allerdale" },
                new LocalAuthorities { LocalAuthoritiesName = "Amber Valley" },
                new LocalAuthorities { LocalAuthoritiesName = "Arun" },
                new LocalAuthorities { LocalAuthoritiesName = "Ashfield" },
                new LocalAuthorities { LocalAuthoritiesName = "Ashford" },
                new LocalAuthorities { LocalAuthoritiesName = "Aylesbury Vale" },
                new LocalAuthorities { LocalAuthoritiesName = "Babergh" },
                new LocalAuthorities { LocalAuthoritiesName = "Barking and Dagenham" },
                new LocalAuthorities { LocalAuthoritiesName = "Barnet" },
                new LocalAuthorities { LocalAuthoritiesName = "Barnsley" },
                new LocalAuthorities { LocalAuthoritiesName = "Barrow-in-Furness" },
                new LocalAuthorities { LocalAuthoritiesName = "Basildon" },
                new LocalAuthorities { LocalAuthoritiesName = "Basingstoke and Deane" },
                new LocalAuthorities { LocalAuthoritiesName = "Bassetlaw" },
                new LocalAuthorities { LocalAuthoritiesName = "Bath and North East Somerset" },
                new LocalAuthorities { LocalAuthoritiesName = "Bedford" },
                new LocalAuthorities { LocalAuthoritiesName = "Bexley" },
                new LocalAuthorities { LocalAuthoritiesName = "Birmingham" },
                new LocalAuthorities { LocalAuthoritiesName = "Blaby" },
                new LocalAuthorities { LocalAuthoritiesName = "Blackburn with Darwen" },
                new LocalAuthorities { LocalAuthoritiesName = "Blackpool" },
                new LocalAuthorities { LocalAuthoritiesName = "Bolsover" },
                new LocalAuthorities { LocalAuthoritiesName = "Bolton" },
                new LocalAuthorities { LocalAuthoritiesName = "Boston" },
                new LocalAuthorities { LocalAuthoritiesName = "Bournemouth" },
                new LocalAuthorities { LocalAuthoritiesName = "Bracknell Forest" },
                new LocalAuthorities { LocalAuthoritiesName = "Bradford" },
                new LocalAuthorities { LocalAuthoritiesName = "Braintree" },
                new LocalAuthorities { LocalAuthoritiesName = "Breckland" },
                new LocalAuthorities { LocalAuthoritiesName = "Brent" },
                new LocalAuthorities { LocalAuthoritiesName = "Brentwood" },
                new LocalAuthorities { LocalAuthoritiesName = "Brighton and Hove" },
                new LocalAuthorities { LocalAuthoritiesName = "Bristol, City of" },
                new LocalAuthorities { LocalAuthoritiesName = "Broadland" },
                new LocalAuthorities { LocalAuthoritiesName = "Bromley" },
                new LocalAuthorities { LocalAuthoritiesName = "Bromsgrove" },
                new LocalAuthorities { LocalAuthoritiesName = "Broxbourne" },
                new LocalAuthorities { LocalAuthoritiesName = "Broxtowe" },
                new LocalAuthorities { LocalAuthoritiesName = "Buckinghamshire" },
                new LocalAuthorities { LocalAuthoritiesName = "Burnley" },
                new LocalAuthorities { LocalAuthoritiesName = "Bury" },
                new LocalAuthorities { LocalAuthoritiesName = "Calderdale" },
                new LocalAuthorities { LocalAuthoritiesName = "Cambridge" },
                new LocalAuthorities { LocalAuthoritiesName = "Cambridgeshire" },
                new LocalAuthorities { LocalAuthoritiesName = "Camden" },
                new LocalAuthorities { LocalAuthoritiesName = "Cannock Chase" },
                new LocalAuthorities { LocalAuthoritiesName = "Canterbury" },
                new LocalAuthorities { LocalAuthoritiesName = "Carlisle" },
                new LocalAuthorities { LocalAuthoritiesName = "Castle Point" },
                new LocalAuthorities { LocalAuthoritiesName = "Central Bedfordshire" },
                new LocalAuthorities { LocalAuthoritiesName = "Charnwood" },
                new LocalAuthorities { LocalAuthoritiesName = "Chelmsford" },
                new LocalAuthorities { LocalAuthoritiesName = "Cheltenham" },
                new LocalAuthorities { LocalAuthoritiesName = "Cherwell" },
                new LocalAuthorities { LocalAuthoritiesName = "Cheshire East" },
                new LocalAuthorities { LocalAuthoritiesName = "Cheshire West and Chester" },
                new LocalAuthorities { LocalAuthoritiesName = "Chesterfield" },
                new LocalAuthorities { LocalAuthoritiesName = "Chichester" },
                new LocalAuthorities { LocalAuthoritiesName = "Chiltern" },
                new LocalAuthorities { LocalAuthoritiesName = "Chorley" },
                new LocalAuthorities { LocalAuthoritiesName = "Christchurch" },
                new LocalAuthorities { LocalAuthoritiesName = "City of London*" },
                new LocalAuthorities { LocalAuthoritiesName = "Colchester" },
                new LocalAuthorities { LocalAuthoritiesName = "Copeland" },
                new LocalAuthorities { LocalAuthoritiesName = "Corby" }
                );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
