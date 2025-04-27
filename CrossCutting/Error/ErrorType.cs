namespace CrossCutting.Error;

public enum ErrorType
{
    ProfileNotFound,
    InvalidProfileName,

    NotFound,    
    InvalidItemId,
    InvalidItemQuantity,
    CartNotFound,
    InsufficientStock,
    InvalidItemPrice,
    ItemNotFound,
    CartItemNotFound,
    InvalidPromotionName,
    InvalidPromotionId,
    PromotionsNotFound,
    InvalidMinimumPrice,
    InvalidMinimumQuantity,
    InvalidPromotionCategory,
    InvalidPromotionType,
    InternalServerError
}
