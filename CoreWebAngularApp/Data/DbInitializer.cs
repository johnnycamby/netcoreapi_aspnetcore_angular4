using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebAngularApp.Models;

namespace CoreWebAngularApp.Data
{
    public static class DbInitializer
    {
        public static void DataSeederContext(this XplicitDbContext context)
        {
            // first, clear the database.  This ensures we can always start 
            // fresh for demo.  Not advised for production environments, obviously :-)

            context.Companies.RemoveRange(context.Companies);
            context.SaveChanges();

            var companies = new List<Company>
            {
                new Company
                {
                    //xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
                    Id = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    CompanyName = "Bugatti",
                    FoundedAt = new DateTimeOffset(new DateTime(1909, 1, 3)),
                    ImageLogo = "images/companies/bugatti.jpg",
                    Overview = "Was a French car manufacturer of high-performance automobiles, founded in 1909 in the then German city of Molsheim, Alsace by Italian-born Ettore Bugatti. Bugatti cars were known for their design beauty (Ettore Bugatti was from a family of artists and considered himself to be both an artist and constructor) and for their many race victories. Famous Bugattis include the Type 35 Grand Prix cars, the Type 41 'Royale', the Type 57 'Atlantic' and the Type 55 sports car. The death of Ettore Bugatti in 1947 proved to be the end for the marque, and the death of his son Jean Bugatti in 1939 ensured there was not a successor to lead the factory. No more than about 8,000 cars were made. The company struggled financially, and released one last model in the 1950s, before eventually being purchased for its airplane parts business in the 1960s. In the 1990s, an Italian entrepreneur revived it as a builder of limited production exclusive sports cars. Today, the name is owned by German automobile manufacturing group Volkswagen.",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                            CarName = "Bugatti Chiron",
                            CarModel = "BUG06A",
                            Description = " Maximum driving performance, breath-taking beauty and fascinating technology combined to create an incomparable driving experience. Ladies and Gentlemen turn up your volume and start your engines",
                            ImageUrl = "images/cars/bugatti-chiron.jpg",
                            Rating = 4
                        },
                        new Car
                        {
                            Id = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                            CarName = "Bugatti Veyron",
                            CarModel = "16.4 Super Sport",
                            Description = "supposed to meet: over 1,000 hp, a top speed of over 400 km/h and the ability to accelerate from 0 to 100 in under three seconds.",
                            ImageUrl = "images/cars/bugatti-veyron-ss.jpg",
                            Rating = 4
                        }
                    }
                },
                new Company
                {
                    Id = new Guid("76053df4-6687-4353-8937-b45556748abe"),
                    CompanyName = "Koenigsegg",
                    FoundedAt = new DateTimeOffset(new DateTime(1994, 3, 2)),
                    ImageLogo = "images/companies/koenigsegg.jpg",
                    Overview = "Is a Swedish manufacturer of high-performance sports cars, based in Ängelholm, Skåne County, Sweden. The company was founded in 1994 in Sweden by Christian von Koenigsegg, with the intention of producing a 'world-class' supercar. Many years of development and prototyping led to the company's first street-legal production car delivery in 2002. In 2006 Koenigsegg began production of the CCX, which uses an engine created in-house especially for that vehicle. The CCX is street-legal in most countries, including the US. In March 2009 the Koenigsegg CCXR was chosen by Forbes to be one of the most beautiful cars in history. In December 2010 the Koenigsegg Agera won the BBC Top Gear Hypercar of the Year Award. Apart from developing, manufacturing and selling the Koenigsegg line of supercars, Koenigsegg is also involved in 'green technology' development programmes beginning with the CCXR ('Flower Power') flexfuel supercar and continuing through the present with the Agera R. Koenigsegg is also active in development programs of plug-in electric cars' systems and next-generation reciprocating engine technologies. Koenigsegg develops and produces most of the main systems, subsystems and components needed for their cars in-house instead of relying on subcontractors. At the end of 2015 Koenigsegg had 97 employees in total with an engineering department of 25 engineers led by Christian von Koenigsegg himself.",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                            CarName = "CCR - Koenigsegg",
                            CarModel = "regera",
                            Description = "claimed the CCR to be the fastest production car with a theoretical top speed of more than 395 km/h (245 mph).",
                            ImageUrl = "images/cars/ccr.jpg",
                            Rating = 4
                        }
                    }
                },

                new Company
                {
                    Id = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"),
                    CompanyName = "Hennessey Performance Engineering",
                    FoundedAt = new DateTimeOffset(new DateTime(2011, 10, 1)),
                    ImageLogo = "images/companies/hennessy.jpg",
                    Overview = "Is an American tuning house specializing in modifying sports and super cars from several brands like Ferrari, Porsche, McLaren, Chevrolet, Dodge, Cadillac, Lotus, Jeep, Ford, GMC, Lincoln and Lexus. Established in 1991 by John Hennessey, their main facility is located west of Houston, Texas. This firm focuses on mechanical component modification for creating high-powered cars. Besides performance automobiles, they also tune sport utility vehicles such as Ford Raptors and Jeep Cherokees. They also work on luxury cars like Bentleys and muscle cars like Dodge Charger and Challenger.",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                            CarName = "Hennessey",
                            CarModel = "Venom GT",
                            Description = "set a Guinness World Record for the fastest production car from 0–186 miles per hour (0–300 km/h) with an average acceleration time of 13.63 seconds.[2] In addition, the car set an unofficial record for 0–200 mph (0–322 km/h) acceleration at 14.51 seconds, beating the Koenigsegg Agera R's time of 17.68 seconds, making it the unofficial fastest accelerating production car in the world.",
                            ImageUrl = "images/cars/hennessey-venom.jpg",
                            Rating = 4
                        }
                    }
                },

                new Company
                {
                    Id = new Guid("578359b7-1967-41d6-8b87-64ab7605587e"),
                    CompanyName = "Ferrari",
                    FoundedAt = new DateTimeOffset(new DateTime(1939, 6, 9)),
                    ImageLogo = "images/companies/ferrari",
                    Overview = "is an Italian sports car manufacturer based in Maranello. Founded by Enzo Ferrari in 1939 as Auto Avio Costruzioni, the company built its first car in 1940. However, the company's inception as an auto manufacturer is usually recognized in 1947 when the first Ferrari-badged car was completed.Ferrari is the world's most powerful brand according to Brand Finance. In May 2012 the 1962 Ferrari 250 GTO became the most expensive car in history, selling in a private transaction for US$38.1 million to American communications magnate Craig McCaw.",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                            CarName = "Ferrari",
                            CarModel = "Laferrari",
                            Description = "",
                            ImageUrl = "images/cars/laferrari.jpg",
                            Rating = 3
                        }
                    }
                },

                new Company
                {
                    Id = new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"),
                    CompanyName = "McLaren-Honda",
                    FoundedAt = new DateTimeOffset(new DateTime(1963, 4,4)),
                    ImageLogo = "images/companies/mclaren.jpg",
                    Overview = "Is a British Formula One team based at the McLaren Technology Centre, Woking, Surrey, England. McLaren is best known as a Formula One constructor but has also competed in and won the Indianapolis 500 and the Canadian-American Challenge Cup (Can-Am). The team is the second oldest active team after Ferrari. They are one of the most successful teams in Formula One history, having won 182 races, 12 drivers' championships and eight constructors' championships. The team is a wholly owned subsidiary of McLaren Technology Group.",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                            CarName = "mclaren P1",
                            CarModel = "675LT",
                            Description = " was the fastest production car in the world – setting a record of 240.1mph – its greatest legacy was its technical innovation. It was the first road car to be built around a carbon fibre tub, a technology pioneered by McLaren in Formula 1, and one that lies at the heart of all of our current models",
                            ImageUrl = "images/cars/mclaren-p1.jpg",
                            Rating = 3
                        }
                    }
                },

                new Company
                {
                    Id = new Guid("a1da1d8e-1988-4634-b538-a01709477b77"),
                    CompanyName = "Aston Martin Lagonda Limited",
                    FoundedAt = new DateTimeOffset(new DateTime(1913, 2, 4)),
                    ImageLogo = "images/companies/aston.jpg",
                    Overview = "Is a British manufacturer of luxury sports cars and grand tourers. It was founded in 1913 by Lionel Martin and Robert Bamford. The firm became associated with luxury grand touring cars in the 1950s and 1960s, and with the fictional character James Bond following his use of a DB5 model in the 1964 film Goldfinger.The company has had a chequered financial history, including bankruptcy in the 1970s, but has also enjoyed long periods of success and stability, including under the ownership of David Brown, from 1947 to 1972 and of the Ford Motor Company from 1994 to 2007",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                            CarName = "Aston Martin",
                            CarModel = "One-77",
                            Description = "a sports car of unparalleled beauty with subtle aggression and performance developed in 2008 and 2009 with the goal of eclipsing any previous Aston Martin road car.",
                            ImageUrl = "images/cars/one-77.jpg",
                            Rating = 3
                        }
                    }
                },

                new Company
                {
                    Id = new Guid("eeb09b29-3514-4ab8-a2c2-10c8a9ba2f8e"),
                    CompanyName = "SSC North America",
                    FoundedAt = new DateTimeOffset(new DateTime(1999, 2,10)),
                    ImageLogo = "images/companies/shelby2.jpg",
                    Overview = "Is an American automobile manufacturer founded in 1998[1] by owner Jerod Shelby (no relation to car designer Carroll Shelby). The company is based in West Richland, near the Tri-Cities, Washington and specialized in the production of sports cars based on a Pontiac Fiero-derived space frame. They built the SSC Aero, a kit car based on a Pontiac Fiero spaceframe chassis, equipped with a twin turbocharged pushrod engined V8s. Its turbocharged 6.35 litres (388 cu in) V8 produces 1,287 bhp (960 kW; 1,305 PS), which made it the most powerful production car in the world, until the arrival of Koenigsegg One:1 (1,341 bhp (1,000 kW; 1,360 PS)) in 2014. On September 13, 2007, the 'Ultimate Aero' took the title of fastest production car. The Ultimate Aero has a top speed of 412 km/h (256 mph). On June 26, 2010 the title was again lost to the upgraded Bugatti Veyron Super Sport that now holds the world speed record for production cars - 267.856 miles per hour (431.072 km/h). In late 2010, there was a design presented as the SSC Tuatara. It is to feature a custom-built V8 engine. The engine was installed in an Ultimate Aero for testing, and is reputed to have also been installed in a Pontiac G8.",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("0dfa52d5-5805-4d10-b344-3048fdf8cc81"),
                            CarName = "Shelby SSC Aero TT",
                            CarModel = "Bullet Aluminum V8 Block",
                            Description = "its  timed at 256.14 mph (412.22 km/h)) until the introduction of the Bugatti Veyron Super Sport in 2010",
                            ImageUrl = "images/cars/sscaero.jpg",
                            Rating = 4
                        }
                    }
                },

                new Company
                {
                    Id = new Guid("ea9c742a-1348-4f4d-aee5-c1d2fc4cebe7"),
                    CompanyName = "Jaguar Cars",
                    FoundedAt = new DateTimeOffset(new DateTime(1922, 4, 9)),
                    ImageLogo = "images/companies/jaguar.jpg",
                    Overview = "Is the luxury vehicle brand of Jaguar Land Rover, a British multinational car manufacturer with its headquarters in Whitley, Coventry, England, owned by the Indian company Tata Motors since 2008. Jaguar's business was founded as the Swallow Sidecar Company in 1922, originally making motorcycle sidecars before developing bodies for passenger cars. Under the ownership of S. S. Cars Limited the business extended to complete cars made in association with Standard Motor Co many bearing Jaguar as a model name. The company's name was changed from S. S. Cars to Jaguar Cars in 1945. A merger with the British Motor Corporation followed in 1966, the resulting enlarged company now being renamed as British Motor Holdings (BMH), which in 1968 merged with Leyland Motor Corporation and became British Leyland, itself to be nationalised in 1975. Jaguar was de-merged from British Leyland and was listed on the London Stock Exchange in 1984, becoming a constituent of the FTSE 100 Index until it was acquired by Ford in 1990. Jaguar has, in recent years, manufactured cars for the British Prime Minister, the most recent delivery being an XJ in May 2010. The company also holds royal warrants from Queen Elizabeth II and Prince Charles. Jaguar cars today are designed in Jaguar Land Rover's engineering centres at the Whitley plant in Coventry and at their Gaydon site in Warwickshire, and are assembled in their plants at Castle Bromwich and Solihull. In September 2013 Jaguar Land Rover announced plans to open a 100 million GBP (160 million USD) research and development centre in the University of Warwick, Coventry to create a new generation of vehicle technologies.",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("f855cd2a-7e07-44dc-8d5b-cfdbad54f96a"),
                            CarName = "Jaguar",
                            CarModel = "XJ220",
                            Description = "officially recorded a top speed of 212.3 mph (341.7 km/h) during testing by Jaguar",
                            ImageUrl = "images/cars/xj220.jpg",
                            Rating = 3
                        }
                    }
                },

                new Company
                {
                    Id = new Guid("7a0b0f6d-f1f0-4b29-94f9-7411602be9f1"),
                    CompanyName = "Automobili Lamborghini S.p.A.",
                    FoundedAt = new DateTimeOffset(new DateTime(1963, 2,10)),
                    ImageLogo = "images/companies/lamborghini.jpg",
                    Overview = "Is an Italian brand and manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese, Italy. The company is owned by the Volkswagen Group through its subsidiary Audi. In 2015, Lamborghini's 1,175 employees produced 3,248 vehicles. Ferruccio Lamborghini, an Italian manufacturing magnate, founded Automobili Ferruccio Lamborghini S.p.A. in 1963 to compete with established marques, including Ferrari. The company gained wide acclaim in 1966 for the Miura sports coupé, which established rear mid-engine, rear wheel drive as the standard layout for high-performance cars of the era. Lamborghini grew rapidly during its first decade, but sales plunged in the wake of the 1973 worldwide financial downturn and the oil crisis. The firm's ownership changed three times after 1973, including a bankruptcy in 1978. American Chrysler Corporation took control of Lamborghini in 1987 and sold it to Malaysian investment group Mycom Setdco and Indonesian group V'Power Corporation in 1994. In 1998, Mycom Setdco and V'Power sold Lamborghini to the Volkswagen Group where it was placed under the control of the group's Audi division. New products and model lines were introduced to the brand's portfolio and brought to the market and saw an increased productivity for the brand Lamborghini. In the late 2000s, during the worldwide financial crisis and the subsequent economic crisis, Lamborghini's sales saw a drop of nearly 50 percent.",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("0895fe70-0c50-45f1-8ee0-46515b14fde2"),
                            CarName = "Lamborghini",
                            CarModel = "Veneno Roadster",
                            Description = "takes the aerodynamic efficiency of a racing prototype onto everyday roads. This super sports car is characterized by optimal aerodynamics in order to guarantee stability in fast curves and a behavior like a racing prototype. All of this on a car devised for the road. The perfect car for sports-driving lovers.",
                            ImageUrl = "images/cars/lamborghini.jpg",
                            Rating = 3
                        }
                    }
                },

                new Company
                {
                    Id = new Guid("902d2c5d-470a-4298-9092-1a32a60d545d"),
                    CompanyName = "Bentley Motors Limited",
                    FoundedAt = new DateTimeOffset(new DateTime(1919, 11, 1)),
                    ImageLogo = "images/companies/bentley.jpg",
                    Overview = "is a British registered company that designs, develops, and manufactures Bentley luxury motorcars which are largely hand-built. It is a subsidiary of Volkswagen AG.[12] Now based in Crewe, England, Bentley Motors Limited was founded by W. O. Bentley on 18 January 1919 in Cricklewood, North London. Bentley cars are sold via franchised dealers worldwide, and as of November 2012, China was the largest market.Most Bentley cars are assembled at the Crewe factory, but a small number of Continental Flying Spurs are assembled at the factory in Dresden, Germany.[14] Bodies for the Continental are produced in Zwickau, Germany. Bentley won the 24 Hours of Le Mans in 1924, 1927, 1928, 1929, 1930, and 2003. Iconic Bentley models include the Bentley 4½ Litre, Bentley Speed Six, Bentley R Type Continental, Bentley Turbo R, and Bentley Arnage. As of 2015, Bentley produce the Continental Flying Spur, Continental GT, Bentley Bentayga and the Mulsanne. Rolls-Royce bought Bentley from the receivers in 1931 and subsequently sold it to Vickers plc in 1980 when Rolls-Royce themselves went bankrupt. In 1998, Vickers sold it to Volkswagen AG. The sale included the vehicle designs, model nameplates, production and administrative facilities, the Spirit of Ecstasy and Rolls-Royce grille shape trademarks, but not the rights to the Rolls-Royce name or logo which are owned by Rolls-Royce Holdings plc and were licensed to BMW AG.",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("690c2ecd-6704-4d6f-8a5b-55863ae58b41"),
                            CarName = "Bentley",
                            CarModel = "Continental Supersports",
                            Description = " is equipped with a 6.0 litre twin-turbocharged W12 engine, which produces a DIN-rated motive power output of 560 metric horsepower (412 kW; 552 bhp) at 6,100 rpm, and torque of 650 newton metres (479 lbf·ft) at 1,600-6,100 rpm.[2] Torsen-based permanent four-wheel drive is standard.[2] It will accelerate from 0 to 100 kilometres per hour (0.0 to 62.1 mph) in 4.8 seconds, and go on to reach a top speed of 318 kilometres per hour (197.6 mph)",
                            ImageUrl = "images/cars/bentley.jpg",
                            Rating = 3
                        }
                    }
                },

                new Company
                {
                    Id = new Guid("936a64cc-fab3-4d3c-b2a7-0876ee275728"),
                    CompanyName = "Maserati S.p.A.",
                    FoundedAt = new DateTimeOffset(new DateTime(1914, 1, 12)),
                    ImageLogo = "images/companiess/Maserati.jpg",
                    Overview = "The company's headquarters are now in Modena, and its emblem is a trident. It has been owned by the Italian–American car giant Fiat Chrysler Automobiles (FCA) and FCA's Italian predecessor Fiat S.p.A. since 1993. Maserati was initially associated with Ferrari S.p.A., which               was also owned by FCA until being spun off in 2015, but more recently it has become part of the sports car group including Alfa Romeo and Abarth (see section below). In May 2014, due to ambitious plans and product launches, Maserati sold a record of over 3,000 cars. This                 caused them to increase production of the Quattroporte and Ghibli models. In addition to the Ghibli and Quattroporte, Maserati offers the Maserati GranTurismo, the GranTurismo Convertible, and has confirmed that it will be offering the Maserati Levante, the first Maserati               SUV, in 2016, and the Maserati Alfieri, a new 2+2 in 2016. Maserati is placing a production output cap at 75,000 vehicles globally",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Id = new Guid("4bf56b53-8797-4390-aa09-bd22939b0aee"),
                            CarName = "Maserati",
                            CarModel = "Quattroporte GTS",
                            Description = "The Maserati tagline is Luxury, sports and style cast in exclusive cars. ultra-luxury performance automobiles with timeless Italian style, accommodating bespoke interiors, and effortless, signature sounding power",
                            ImageUrl = "images/cars/Maserati.jpg",
                            Rating = 3
                        }
                    }
                }
            };

            context.Companies.AddRange(companies);
            context.SaveChanges();
        }
    }
}