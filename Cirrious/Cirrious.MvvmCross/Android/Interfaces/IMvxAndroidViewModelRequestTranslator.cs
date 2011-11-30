#region Copyright

// <copyright file="IMvxAndroidViewModelRequestTranslator.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using Android.Content;
using Cirrious.MvvmCross.Views;

namespace Cirrious.MvvmCross.Android.Interfaces
{
    public interface IMvxAndroidViewModelRequestTranslator
    {
        MvxShowViewModelRequest GetRequestFromIntent(Intent intent);
        Intent GetIntentFor(MvxShowViewModelRequest request);
    }
}