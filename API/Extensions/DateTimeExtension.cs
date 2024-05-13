namespace API.Extensions
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateOnly dob)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - dob.Year;
            if (dob.AddYears(age) > today)
            {
                age--;
            }

            return age;
        }
    }
}