using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _5125Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        /// <summary>
        /// Returns a welcome message.
        /// </summary>
        /// <returns>A string message: "Welcome to 5125!"</returns>
        /// <example>
        /// GET https://localhost:xx/api/q1/Welcome
        /// </example>
        [HttpGet(template: "/api/q1/Welcome")]
        public string GetWelcomeMessage()
        {
            return "Welcome to 5125!";
        }

        /// <summary>
        /// Returns a greeting message for the provided name.
        /// </summary>
        /// <param name="name">The name to include in the greeting.</param>
        /// <returns>A string message: "Hi {name}!"</returns>
        /// <example>
        /// GET https://localhost:xx/api/q2/Greeting?name=Gary
        /// </example>
        [HttpGet(template: "/api/q2/Greeting")]
        public string GetGreeting([FromQuery] string name)
        {
            return string.IsNullOrWhiteSpace(name) ? "Name parameter is required." : $"Hi {name}!";
        }

        /// <summary>
        /// Returns the cube of the provided integer.
        /// </summary>
        /// <param name="baseValue">The integer to be cubed.</param>
        /// <returns>The cube of the provided integer.</returns>
        /// <example>
        /// GET https://localhost:xx/api/q3/Cube/4
        /// </example>
        [HttpGet(template: "/api/q3/Cube/{baseValue}")]
        public long GetCube(int baseValue)
        {
            return (long)Math.Pow(baseValue, 3);
        }

        /// <summary>
        /// Returns the start of a knock-knock joke.
        /// </summary>
        /// <returns>A string message: "Who’s there?"</returns>
        /// <example>
        /// POST https://localhost:xx/api/q4/KnockKnock
        /// </example>
        [HttpPost(template: "/api/q4/KnockKnock")]
        public string GetKnockKnockJoke()
        {
            return "Who’s there?";
        }

        /// <summary>
        /// Acknowledges the provided secret integer.
        /// </summary>
        /// <param name="secret">The secret integer provided in the request body.</param>
        /// <returns>A string message: "Shh.. the secret is {secret}"</returns>
        /// <example>
        /// POST https://localhost:xx/api/q5/Secret
        /// </example>
        [HttpPost(template: "/api/q5/Secret")]
        public string PostSecret([FromBody] int secret)
        {
            return $"Shh.. the secret is {secret}";
        }

        /// <summary>
        /// Returns the area of a regular hexagon with side length double the provided value.
        /// </summary>
        /// <param name="side">The side length of the hexagon.</param>
        /// <returns>The area of the hexagon.</returns>
        /// <example>
        /// GET https://localhost:xx/api/q6/Hexagon?side=1
        /// </example>
        [HttpGet(template: "/api/q6/Hexagon")]
        public double GetHexagonArea([FromQuery] double side)
        {
            return (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
        }

        /// <summary>
        /// Returns the date adjusted by the specified number of days.
        /// </summary>
        /// <param name="days">The number of days to adjust the current date by.</param>
        /// <returns>The adjusted date in yyyy-MM-dd format.</returns>
        /// <example>
        /// GET https://localhost:xx/api/q7/TimeMachine?days=1
        /// </example>
        [HttpGet(template: "/api/q7/TimeMachine")]
        public string GetAdjustedDate([FromQuery] int days)
        {
            return DateTime.Today.AddDays(days).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Returns the checkout summary for an order of SquashFellows plushies.
        /// </summary>
        /// <param name="small">The number of small plushies ordered.</param>
        /// <param name="large">The number of large plushies ordered.</param>
        /// <returns>A string summarizing the order.</returns>
        /// <example>
        /// POST https://localhost:xx/api/q8/SquashFellows
        /// </example>
        [HttpPost(template: "/api/q8/SquashFellows")]
        public string PostSquashFellowsOrder([FromForm] int small, [FromForm] int large)
        {
            const double smallPrice = 25.50;
            const double largePrice = 40.50;
            const double taxRate = 0.13;

            double subtotal = (small * smallPrice) + (large * largePrice);
            double tax = Math.Round(subtotal * taxRate, 2);
            double total = Math.Round(subtotal + tax, 2);

            return $"{small} Small @ ${smallPrice} = ${small * smallPrice:F2}; " +
                   $"{large} Large @ ${largePrice} = ${large * largePrice:F2}; " +
                   $"Subtotal = ${subtotal:F2}; Tax = ${tax:F2} HST; Total = ${total:F2}";
        }
    }
}
