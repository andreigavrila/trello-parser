using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace MyTrelloParser.Test
{
    [TestClass]
    public class CardTests
    {
        private string jsonString = @"{
                          'id': '5b3912823e56cf5cbbb62f3c',
                          'checkItemStates': null,
                          'closed': false,
                          'creationMethod': null,
                          'dateLastActivity': '2018-10-20T19:11:29.336Z',
                          'descData': { 'emoji': {
                                    }
                                },
                          'idBoard': '5a48f2e96a8498cbd0ee1a9e',
                          'idList': '5bb314fee854c333677d8a0e',
                          'idMembersVoted': [ ],
                          'idShort': 494,
                          'idAttachmentCover': '5b39129d8868685aa7009ffe',
                          'limits': {
                            'attachments': {
                              'perCard': {
                                'status': 'ok',
                                'disableAt': 950,
                                'warnAt': 900
                              }
                            },
                            'checklists': {
                              'perCard': {
                                'status': 'ok',
                                'disableAt': 475,
                                'warnAt': 450
                              }
                            },
                            'stickers': {
                              'perCard': {
                                'status': 'ok',
                                'disableAt': 67,
                                'warnAt': 63
                              }
                            }
                          },
                          'idLabels': [ '5a48f2e99ae3d60b0c7cb60e', '5b5496748344b10fc35c3076', '5ace3490a056dd5e2cb4e393', '5a48f319d4a34696958f1a5f' ],
                          'manualCoverAttachment': false,
                          'name': '[Book] Thinking, Fast and Slow',
                          'pos': 14974975,
                          'shortLink': 'aa8LE1uG',
                          'badges': {
                            'votes': 0,
                            'attachmentsByType': {
                              'trello': {
                                'board': 0,
                                'card': 0
                              }
                            },
                            'viewingMemberVoted': false,
                            'subscribed': false,
                            'fogbugz': '',
                            'checkItems': 2,
                            'checkItemsChecked': 0,
                            'comments': 3,
                            'attachments': 1,
                            'description': true,
                            'due': null,
                            'dueComplete': false
                          },
                          'dueComplete': false,
                          'due': null,
                          'email': 'andreigavrila+2drpkivd0vdjokosf4y+2qjchmgf1fk68238g8s+2amuijzoof@boards.trello.com',
                          'idChecklists': [ '5bcb75a20a697d1d25bf95db' ],
                          'idMembers': [ ],
                          'labels': [
                            {
                              'id': '5a48f2e99ae3d60b0c7cb60e',
                              'idBoard': '5a48f2e96a8498cbd0ee1a9e',
                              'name': 'Great',
                              'color': 'green'
                            },
                            {
                              'id': '5b5496748344b10fc35c3076',
                              'idBoard': '5a48f2e96a8498cbd0ee1a9e',
                              'name': 'Level Competent',
                              'color': null
                            },
                            {
                              'id': '5ace3490a056dd5e2cb4e393',
                              'idBoard': '5a48f2e96a8498cbd0ee1a9e',
                              'name': 'Learning',
                              'color': null
                            },
                            {
                              'id': '5a48f319d4a34696958f1a5f',
                              'idBoard': '5a48f2e96a8498cbd0ee1a9e',
                              'name': 'Agile',
                              'color': null
                            }
                          ],
                          'shortUrl': 'https://trello.com/c/aa8LE1uG',
                          'subscribed': false,
                          'url': 'https://trello.com/c/aa8LE1uG/494-book-thinking-fast-and-slow',
                          'attachments': [
                            {
                              'bytes': 56079,
                              'date': '2018-07-01T17:42:53.079Z',
                              'edgeColor': '#fcfcf4',
                              'idMember': '4f672b5339e5c3c004e163a2',
                              'isUpload': true,
                              'mimeType': null,
                              'name': 'image.png',
                              'previews': [
                                {
                                  'bytes': 2227,
                                  'url': 'https://trello-attachments.s3.amazonaws.com/5b3912823e56cf5cbbb62f3c/70x50/3ea4a5d066b7df710628827ee5b772dc/image.png',
                                  'height': 50,
                                  'width': 70,
                                  '_id': '5b39129d41c93be902597c19',
                                  'scaled': false
                                },
                                {
                                  'bytes': 13978,
                                  'url': 'https://trello-attachments.s3.amazonaws.com/5b3912823e56cf5cbbb62f3c/250x150/e1aa7c03e95892450bf298e10a1f1283/image.png',
                                  'height': 150,
                                  'width': 250,
                                  '_id': '5b39129d41c93be902597c18',
                                  'scaled': false
                                },
                                {
                                  'bytes': 27538,
                                  'url': 'https://trello-attachments.s3.amazonaws.com/5b3912823e56cf5cbbb62f3c/150x223/55ac98a327128f03c841d73ddae9f27c/image.png',
                                  'height': 223,
                                  'width': 150,
                                  '_id': '5b39129d41c93be902597c17',
                                  'scaled': true
                                },
                                {
                                  'bytes': 56079,
                                  'height': 327,
                                  'width': 220,
                                  'url': 'https://trello-attachments.s3.amazonaws.com/5a48f2e96a8498cbd0ee1a9e/5b3912823e56cf5cbbb62f3c/9972ba4e6db41e88d3ff933f5494a1cd/image.png',
                                  '_id': '5b39129d41c93be902597c16',
                                  'scaled': true
                                }
                              ],
                              'url': 'https://trello-attachments.s3.amazonaws.com/5a48f2e96a8498cbd0ee1a9e/5b3912823e56cf5cbbb62f3c/9972ba4e6db41e88d3ff933f5494a1cd/image.png',
                              'pos': 16384,
                              'id': '5b39129d8868685aa7009ffe'
                            }
                          ],
                          'pluginData': [ ],
                          'customFieldItems': [ ]
                        }";

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Card_JsonWithoutNameThrowsException()
        {
            //arrage
            string json = "somestring";

            //act
            Card sut = new Card(json);

            //assert
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Card_CreatingACardWithANullStringThrowsException()
        {
            //arrage
            string json = null;

            //act
            Card sut = new Card(json);
        }

        [TestMethod]
        public void Card_ICanCreateNewCardWithARealJsonString()
        {
            //arrage
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            //act
            Card sut = new Card(json);

            //assert
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public void Card_ContentTypeIsCorrect()
        {
            //arrage
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            //act
            Card sut = new Card(json);

            //assert
            Assert.IsNotNull(sut.ContentType);
            Assert.AreEqual("Book", sut.ContentType);
        }

        [TestMethod]
        public void Card_CardNameIsCorrect()
        {
            //arrage
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            //act
            Card sut = new Card(json);

            //assert
            Assert.IsNotNull(sut.Name);
            Assert.AreEqual("Thinking, Fast and Slow", sut.Name);
        }

        [TestMethod]
        public void Card_CardWithoutContentTypeHasAProblem()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Card_CardRecommendationTypeIsCorrect()
        {
            //arrage
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            //act
            Card sut = new Card(json);

            //assert
            Assert.IsNotNull(sut.RecomandationType);
            Assert.AreEqual(RecomandationTypeEnum.Great, sut.RecomandationType);
        }

        [TestMethod]
        public void Card_CardLabelsAreCorrect()
        {
            //arrage
            dynamic json = JsonConvert.DeserializeObject(jsonString);

            //act
            Card sut = new Card(json);

            //assert
            Assert.AreEqual(3 ,sut.Labels.Count);
            Assert.IsTrue(sut.Labels.Contains("Level Competent"));
            Assert.IsTrue(sut.Labels.Contains("Learning"));
            Assert.IsTrue(sut.Labels.Contains("Agile"));
        }
    }
}
