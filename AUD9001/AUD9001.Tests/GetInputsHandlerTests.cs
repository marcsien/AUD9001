using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.Models;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AUD9001.Tests
{
    [TestClass]
    public class GetInputsHandlerTests
    {
        private readonly List<Input> inputList = new List<Input>()
        { 
            new Input(){Id = 1 , Description = "Example Description 1", Name = "ExampleName1", ProcessID = 1 },
            new Input(){Id = 2 , Description = "Example Description 2", Name = "ExampleName2", ProcessID = 1 },
            new Input(){Id = 3 , Description = "Example Description 3", Name = "ExampleName3", ProcessID = 1 },
            new Input(){Id = 4 , Description = "Example Description 4", Name = "ExampleName4", ProcessID = 1 },
            new Input(){Id = 5 , Description = "Example Description 5", Name = "ExampleName5", ProcessID = 1 },
        };
        private readonly Mock<IMediator> mediator;
        public GetInputsHandlerTests()
        {
            this.mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<GetInputsRequest>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new GetInputsResponse() { Data = inputList });
        }

        [TestMethod]
        [Owner("marcsien")]
        [Priority(1)]
        [TestCategory("HandlersTests")]
        public async Task GetInputsRequest_ReturnsGetInputsResponse()
        {
            //Arrange
            GetInputsRequest request = new GetInputsRequest();

            //Act
            var result = await this.mediator.Object.Send(request);

            //Assert
            mediator.Verify(x => x.Send(It.IsAny<GetInputsRequest>(), It.IsAny<CancellationToken>()));
            Assert.IsInstanceOfType(result, typeof(GetInputsResponse));
        }

        [TestMethod]
        [Owner("marcsien")]
        [Priority(1)]
        [TestCategory("HandlersTests")]
        public async Task GetInputsRequest_ReturnsGetInputsResponseList()
        {
            //Arrange
            GetInputsRequest request = new GetInputsRequest();

            //Act
            var result = await this.mediator.Object.Send(request);

            //Assert
            mediator.Verify(x => x.Send(It.IsAny<GetInputsRequest>(), It.IsAny<CancellationToken>()));
            Assert.AreEqual(result.Data, inputList);
        }

    }
}
