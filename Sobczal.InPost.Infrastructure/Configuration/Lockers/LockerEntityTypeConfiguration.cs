using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobczal.InPost.Models.Packages;

namespace Sobczal.InPost.Infrastructure.Configuration.Lockers;

public class LockerEntityTypeConfiguration : IEntityTypeConfiguration<Locker>
{
    public void Configure(EntityTypeBuilder<Locker> builder)
    {
        builder.HasData(
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW333M",
                Address = "ul. Jagiellońska 7, 03-721 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW166M",
                Address = "ul. Targowa 24, 03-733 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW36A",
                Address = "ul. Kijowska 20, 03-743 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW642M",
                Address = "ul. Żupnicza 15, 03-821 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW44H",
                Address = "ul. Mińska 69/U-5, 03-828 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW343M",
                Address = "ul. Kickiego 21 A, 04-390 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW106M",
                Address = "ul. Chrzanowskiego 4, 04-381 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW15H",
                Address = "ul. Przeworska 7, 04-382 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW08N",
                Address = "ul. Zabraniceka 20 / Rzeczna 20, 03-872 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW130AP",
                Address = "ul. Birżanska 1, 03-780 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW15A",
                Address = "ul. Wincentego 4, 03-505 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW431M",
                Address = "ul. Lidzka 5, 03-523 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW127AP",
                Address = "ul. Odrowąża 7A, 03-310 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW465M",
                Address = "ul. Jagiellońska 82B, 03-301 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW30B",
                Address = "ul. Jagiellońska 57/5, 03-301 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW92N",
                Address = "ul. Popiełuszki 17b, 01-711 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW87AP",
                Address = "ul. Broniewskiego 26, 01-771 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW18M",
                Address = "ul. Kochanowskiego 10A, 01-716 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW39M",
                Address = "ul. Josepha Conrada 1, 01-922 Warszawa",
            },
            new Locker()
            {
                Id = Guid.NewGuid(),
                Name = "WAW395M",
                Address = "ul. Pabla Nerudy 1, 01-926 Warszawa",
            }
        );
    }
}