﻿using Recipes.Client.Core.Navigation;

namespace Recipes.Mobile.Navigation;

public interface INavigationInterceptor
{
    Task OnNavigatedTo(object bindingContext, NavigationType navigationType);
}
