using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.Windsor
{
    public static class TestHelperExtensions
    {
        /// <summary>
        /// http://stackoverflow.com/questions/9253388/in-castle-windsor-3-override-an-existing-component-registration-in-a-unit-test
        /// </summary>
        private static ComponentRegistration<T> OverridesExistingRegistration<T>(this ComponentRegistration<T> componentRegistration) where T : class
        {
            return componentRegistration
                                .Named(Guid.NewGuid().ToString())
                                .IsDefault();
        }
        public static IWindsorContainer RegisterMock<TMockObject>(this IWindsorContainer container, Mock<TMockObject> mock) where TMockObject : class
        {
            return container.Register(Component.For<TMockObject>().Instance(mock.Object).OverridesExistingRegistration());
        }

    }
}
