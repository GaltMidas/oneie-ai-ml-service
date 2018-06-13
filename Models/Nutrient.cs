namespace oneie_ai_ml_service.Models
{
    public class Nutrient
    {
        public string FoodId { get; set; }
        public string NutrientId { get; set; }

        public NutrientDefinition Definition { get; set; }

        public double AmountInHundredGrams { get; set; }

    }
}
