using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile.ItemTemplateSelectors;

public class UserReviewDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate OnlyRatingTemplate { get; set; }
    public DataTemplate RatingAndReviewTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is UserReviewViewModel review)
            return string.IsNullOrEmpty(review.Review) ? OnlyRatingTemplate : RatingAndReviewTemplate;

        return null;
    }
}
