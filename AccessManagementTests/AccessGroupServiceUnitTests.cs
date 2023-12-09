using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Classes;
using AccessManagementApp.Services.Interfaces;
using Microsoft.VisualBasic;
using AutoMapper;
using AccessManagementApp;
using AccessManagementApp.Entities;

namespace AccessManagementTests
{
    public class Tests
    {
        UnitOfWorkMock _unitOfWorkMock;
        IAccessGroupService _accessGroupService;
        IMapper mapper;
        List<Access> Accesses { get; set; }
        List<AccessGroup> AccessGroups { get; set; }

        [SetUp]
        public void Setup()
        {
            Accesses = new List<Access>
            {
                new Access { Id = 1, Name = "Patient Data Analysis" },
                new Access { Id = 2, Name = "X-rays" },
                new Access { Id = 3, Name = "Patient Records" },
                new Access { Id = 4, Name = "Laboratory Results" },
                new Access { Id = 5, Name = "MRI Scans" },
                new Access { Id = 6, Name = "Prescription Information" },
                new Access { Id = 7, Name = "Ultrasound Images" }
            };

            AccessGroups = new List<AccessGroup>
            {
                new AccessGroup { Id = 1, Name = "Medical Staff Access", Accesses = new List<Access>
                {
                    Accesses[3],
                    Accesses[4],
                    Accesses[2]
                }
                },
                new AccessGroup { Id = 2, Name = "Psychiatry Access", Accesses = new List<Access>
                {
                    Accesses[5],
                    Accesses[1],
                    Accesses[6]
                }
                },
                new AccessGroup { Id = 3, Name = "Prescription Access", Accesses = new List<Access>
                {
                    Accesses[1],
                    Accesses[2],
                    Accesses[0]
                }
                }
            };

            _unitOfWorkMock = new UnitOfWorkMock(AccessGroups);
            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperSettings());
            });

            mapper = mappingConfig.CreateMapper();
            _accessGroupService = new AccessGroupService(_unitOfWorkMock, mapper);
        }

        [Test]
        public async Task AddCorrectAccessGroup()
        {
            AccessGroup accessGroup = new AccessGroup { Name = "TestName", Accesses = new List<Access> {
                Accesses[1],
                Accesses[0],
                Accesses[2],
                Accesses[3]
            }};

            await _accessGroupService.Create(mapper.Map<CreateAccessGroupModel>(accessGroup));

            var actualAccessGroups = (await _unitOfWorkMock.AccessGroups.GetAll()).ToList();
            
            accessGroup.Id = actualAccessGroups.Max(x => x.Id);

            var expectedResult = AccessGroups.ToList();

            expectedResult.Add(accessGroup);

            Assert.That(actualAccessGroups, Has.Count.EqualTo(expectedResult.Count));

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.That(actualAccessGroups[i].Name, Is.EqualTo(expectedResult[i].Name));

                var expectedAccesses = expectedResult[i].Accesses.ToList();
                var actualAccesses = actualAccessGroups[i].Accesses.ToList();

                for (int j = 0; j < expectedAccesses.Count; j++)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(actualAccesses[j].Id, Is.EqualTo(expectedAccesses[j].Id));
                        Assert.That(actualAccesses[j].Name, Is.EqualTo(expectedAccesses[j].Name));
                    });
                }
            }
        }


        [Test]
        public void AddEmptyAccessGroup()
        {
            AccessGroup accessGroup = new ();

            var exception = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _accessGroupService.Create(mapper.Map<CreateAccessGroupModel>(accessGroup));
            });     
        }

        [Test]
        public void AddAccessGroupWithoutName()
        {
            AccessGroup accessGroup = new() {
                Accesses = new List<Access> {
                Accesses[1],
                Accesses[0],
                Accesses[2],
                Accesses[3]
            }
            };

            var exception = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _accessGroupService.Create(mapper.Map<CreateAccessGroupModel>(accessGroup));
            });
        }

        [Test]
        public void AddAccessGroupWithoutAccesses()
        {
            AccessGroup accessGroup = new()
            {
                Name = "TestName"
            };

            var exception = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _accessGroupService.Create(mapper.Map<CreateAccessGroupModel>(accessGroup));
            });
        }

        [Test]
        public async Task DeleteExistingAccessGroup()
        {
            var agInput = AccessGroups[2];

            var actual = await _accessGroupService.Delete(agInput.Id);

            CollectionAssert.DoesNotContain(await _unitOfWorkMock.AccessGroups.GetAll(), actual);
        }

        [Test]
        public void DeleteNotExistingAccessGroup()
        {
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _accessGroupService.Delete(10);
            });
        }

        [Test]
        public async Task GetAllAccessGroups()
        {
            var actual = (await _accessGroupService.GetAll()).ToList();

            var expected = mapper.Map<List<AccessGroupModel>>(AccessGroups);

            Assert.That(actual, Has.Count.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i].Name, Is.EqualTo(expected[i].Name));

                var expectedAccesses = expected[i].Accesses.ToList();
                var actualAccesses = actual[i].Accesses.ToList();

                for (int j = 0; j < expectedAccesses.Count; j++)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(actualAccesses[j].Id, Is.EqualTo(expectedAccesses[j].Id));
                        Assert.That(actualAccesses[j].Name, Is.EqualTo(expectedAccesses[j].Name));
                    });
                }
            }
        }

        [Test]
        public async Task EditExistingAccessGroup()
        {
            AccessGroup accessGroup = new AccessGroup
            {
                Id = 2,
                Name = "TestName",
                Accesses = new List<Access> {
                Accesses[1],
                Accesses[0],
                Accesses[2],
                Accesses[3],
                Accesses[4]
            }
            };

            await _accessGroupService.Update(mapper.Map<UpdateAccessGroupModel>(accessGroup));

            var actualAccessGroups = (await _unitOfWorkMock.AccessGroups.GetAll()).ToList();

            var expectedResult = AccessGroups.ToList();

            var index = expectedResult.FindIndex(x => x.Id == accessGroup.Id);

            expectedResult[index] = accessGroup;

            Assert.That(actualAccessGroups, Has.Count.EqualTo(expectedResult.Count));

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.That(actualAccessGroups[i].Name, Is.EqualTo(expectedResult[i].Name));

                var expectedAccesses = expectedResult[i].Accesses.ToList();
                var actualAccesses = actualAccessGroups[i].Accesses.ToList();

                for (int j = 0; j < expectedAccesses.Count; j++)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(actualAccesses[j].Id, Is.EqualTo(expectedAccesses[j].Id));
                        Assert.That(actualAccesses[j].Name, Is.EqualTo(expectedAccesses[j].Name));
                    });
                }
            }
        }


        [Test]
        public void EditNotExistingAccessGroup()
        {
            AccessGroup accessGroup = new AccessGroup
            {
                Id = 10,
                Name = "TestName",
                Accesses = new List<Access> {
                Accesses[1],
                Accesses[0],
                Accesses[2],
                Accesses[3],
                Accesses[4]
            }
            };

            var exception = Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _accessGroupService.Update(mapper.Map<UpdateAccessGroupModel>(accessGroup));
            });
        }

        [Test]
        public void EditAccessGroupWithoutName()
        {
            AccessGroup accessGroup = new AccessGroup
            {
                Id = 10,
                Accesses = new List<Access> {
                Accesses[1],
                Accesses[0],
                Accesses[2],
                Accesses[3],
                Accesses[4]
            }
            };

            var exception = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _accessGroupService.Update(mapper.Map<UpdateAccessGroupModel>(accessGroup));
            });
        }

        [Test]
        public void EditAccessGroupWithoutAccesses()
        {
            AccessGroup accessGroup = new()
            {
                Id = 10,
                Name = "TestName"
            };

            var exception = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _accessGroupService.Update(mapper.Map<UpdateAccessGroupModel>(accessGroup));
            });
        }

    }
}