using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseTest<TSystem> where TSystem : class
    {
        protected TSystem GivenTheSystemUnderTest(AutoMock mock)
        {
            var sut = mock.Create<TSystem>();

            return sut;
        }

        protected Mock<T> AndIMockDependencyMethodAsync<T, TResult>(
            AutoMock mock,
            Expression<Func<T, Task<TResult>>> method,
            TResult response) where T : class
        {
            var mockDependency = mock.Mock<T>();

            mockDependency.Setup(method).ReturnsAsync(response);

            return mockDependency;
        }

        protected Mock<T> AndIMockDependencyMethodAsync<T, TParam, TResult>(
            AutoMock mock,
            Expression<Func<T, Task<TResult>>> method,
            TResult response,
            Action<TParam> callback)
            where T : class
        {
            var mockDependency = mock.Mock<T>();

            mockDependency.Setup(method).ReturnsAsync(response).Callback(callback);

            return mockDependency;
        }

        protected Mock<T> AndIMockDependencyMethod<T, TResult>(
            AutoMock mock,
            Expression<Func<T, TResult>> method,
            TResult response)
            where T : class
        {
            var mockDependency = mock.Mock<T>();

            mockDependency.Setup(method).Returns(response);

            return mockDependency;
        }

        protected Mock<T> AndIMockDependencyMethod<T, TParam, TResult>(
            AutoMock mock,
            Expression<Func<T, TResult>> method,
            TResult response,
            Action<TParam> callback)
            where T : class
        {
            var mockDependency = mock.Mock<T>();

            mockDependency.Setup(method).Returns(response).Callback(callback);

            return mockDependency;
        }

        protected Mock<T> AndIMockDependencyMethod<T, TResult>(
            AutoMock mock,
            Expression<Func<T, TResult>> method,
            Exception exception)
            where T : class
        {
            var mockDependency = mock.Mock<T>();

            mockDependency.Setup(method).Throws(exception);

            return mockDependency;
        }

        protected Mock<T> AndIMockDependencyMethod<T, TResult>(
            AutoMock mock,
            Expression<Func<T, Task<TResult>>> method,
            Exception exception)
            where T : class
        {
            var mockDependency = mock.Mock<T>();

            mockDependency.Setup(method).Throws(exception);

            return mockDependency;
        }

        protected Mock<ILogger<TSystem>> AndIMockILogger(AutoMock mock)
        {
            var mockLogger = mock.Mock<ILogger<TSystem>>();

            mockLogger.Setup(x =>
                x.Log(It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    (Func<object, Exception, string>)It.IsAny<object>()));

            return mockLogger;
        }

        protected Mock<IMapper> AndIMockIMapperMap<TSource, TDestination>(AutoMock mock, TDestination response)
        {
            var mockMapper = mock.Mock<IMapper>();

            mockMapper.Setup(m => m.Map<TSource, TDestination>(It.IsAny<TSource>())).Returns(response);

            return mockMapper;
        }

        protected Mock<IMapper> AndIMockIMapperMap<TSource, TDestination>(AutoMock mock, TDestination response, Action<TSource> callback)
        {
            var mockMapper = mock.Mock<IMapper>();

            mockMapper.Setup(m => m.Map<TSource, TDestination>(It.IsAny<TSource>()))
                .Returns(response)
                .Callback(callback).Verifiable();

            return mockMapper;
        }
    }
}
