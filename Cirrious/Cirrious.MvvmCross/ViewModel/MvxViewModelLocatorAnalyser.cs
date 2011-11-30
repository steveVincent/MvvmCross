#region Copyright

// <copyright file="MvxViewModelLocatorAnalyser.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cirrious.MvvmCross.Exceptions;
using Cirrious.MvvmCross.Interfaces.Services;
using Cirrious.MvvmCross.Interfaces.ViewModel;

namespace Cirrious.MvvmCross.ViewModel
{
    public class MvxViewModelLocatorAnalyser : IMvxViewModelLocatorAnalyser
    {
        #region IMvxViewModelLocatorAnalyser Members

        public IEnumerable<MethodInfo> GenerateLocatorMethods(Type locatorType)
        {
            var locators = from methodInfo in locatorType.GetMethods()
                           where IsLocatorCandidate(methodInfo)
                           select methodInfo;

#if DEBUG
            // this to a list (to stop R# complaining about multiple enumeration operations on the Linq)
            locators = locators.ToList();
            CheckLocatorsHaveUniqueName(locators);
#endif

            return locators;
        }

        #endregion

        private static void CheckLocatorsHaveUniqueName(IEnumerable<MethodInfo> methods)
        {
            var locatorsWithMoreThanOneMethod = from method in methods
                                                group method by method.ReturnType.FullName
                                                into grouped
                                                where grouped.Count() > 1
                                                select new {name = grouped.Key};

            var locatorsWithMoreThanOneMethodList = locatorsWithMoreThanOneMethod.ToList();
            if (locatorsWithMoreThanOneMethodList.Count > 0)
                throw new MvxException(
                    "You've built a view model locator with multiple public locator methods and/or get accessors returning the same type - conflicting methods are " +
                    string.Join(",", locatorsWithMoreThanOneMethodList));
        }

        protected static bool IsLocatorParameterCandidate(ParameterInfo parameterInfo)
        {
            return !parameterInfo.IsOut
                   && parameterInfo.ParameterType == typeof (string)
                   && !parameterInfo.IsOptional;
        }

        protected static bool IsLocatorCandidate(MethodInfo methodInfo)
        {
            return methodInfo.IsPublic
                   && !methodInfo.IsStatic
                   && !methodInfo.IsGenericMethod
                   && typeof (IMvxViewModel).IsAssignableFrom(methodInfo.ReturnType)
                   && methodInfo.GetParameters().All(IsLocatorParameterCandidate);
        }
    }
}