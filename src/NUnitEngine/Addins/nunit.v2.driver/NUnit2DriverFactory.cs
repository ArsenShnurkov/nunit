﻿// ***********************************************************************
// Copyright (c) 2014 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Engine.Extensibility;

namespace NUnit.Engine.Drivers
{
    public class NUnit2DriverFactory : IDriverFactory
    {
        private const string NUNIT_FRAMEWORK = "nunit.framework";
        private const string NUNITLITE_FRAMEWORK = "nunitlite";

        /// <summary>
        /// Gets a flag indicating whether a given assembly name and version
        /// represent a test framework supported by this factory.
        /// </summary>
        public bool IsSupportedTestFramework(string assemblyName, Version version)
        {
            return assemblyName == NUNIT_FRAMEWORK && version.Major == 2
                || assemblyName == NUNITLITE_FRAMEWORK && version.Major == 1;
        }

        /// <summary>
        /// Gets a driver for a given test assembly and a framework
        /// which the assembly is already known to reference.
        /// </summary>
        /// <param name="domain">The domain in which the assembly will be loaded</param>
        /// <param name="assemblyName">The name of the test framework reference</param>
        /// <param name="version">The version of the test framework reference</param>
        /// <returns></returns>
        public IFrameworkDriver GetDriver(AppDomain domain, string assemblyName, Version version)
        {
            if (!IsSupportedTestFramework(assemblyName, version))
                throw new ArgumentException("Invalid framework name", "frameworkAssemblyName");

            return new NUnit2FrameworkDriver(domain);
        }
    }
}
