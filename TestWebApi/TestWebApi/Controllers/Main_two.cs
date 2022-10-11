using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    /// <summary>
    /// Основной контроллер
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v2/[controller]")]
    [Produces("application/json")]
    public class Main_two : ControllerBase
    {
        /// <summary>
        /// Получение квадрата числа
        /// </summary>
        /// <response code="200">Успешное возвращение значения</response>
        /// <response code="500">Внутренняя ошибка сервиса</response>
        [HttpGet("Square_two")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public long Square_two(long value1, long value2)
        {
            return value1 * value2;
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <response code="200">Успешное удаление элемента</response>
        /// <response code="400">Ошибка при удалении элемента</response>
        /// <response code="500">Собственная ошибка веб службы</response>
        [HttpDelete("Error_two")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public long Error_two()
        {
            throw new TimeoutException();
        }

    }
}
