#region Copyright

// <copyright file="IMvxViewModelLocator.cs" company="Cirrious">
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

namespace Cirrious.MvvmCross.Interfaces.ViewModel
{
    public interface IMvxViewModelLocator
    {
        bool TryLoad(Type viewModelType, IDictionary<string, string> parameters, out IMvxViewModel model);
    }
}