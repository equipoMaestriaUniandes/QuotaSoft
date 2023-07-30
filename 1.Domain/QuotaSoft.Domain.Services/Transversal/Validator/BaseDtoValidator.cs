namespace Quota.Domain.Services.Transversal.Validator
{
    using System.Globalization;
    using System;
    using System.Linq.Expressions;
    using FluentValidation;

    /// <summary>
    /// The base validator.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class BaseDtoValidator<T> : AbstractValidator<T> 
    {
         /// <summary>
        /// Longitud predeterminada de campos
        /// </summary>
        private readonly int LONGITUD_PREDETERMINADA_CAMPOS = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidator{T}"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public BaseDtoValidator()
        {
            ValidatorOptions.LanguageManager.Culture = new CultureInfo("es");
        }

        /// <summary>
        /// The regla para campo texto.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="msg">
        /// The msg.
        /// </param>
        public void ruleForString(Expression<Func<T, string>> expression, string msg)
        {
            RuleFor(expression).NotEmpty().WithMessage(msg);
            RuleFor(expression).Length(1, LONGITUD_PREDETERMINADA_CAMPOS).WithMessage(msg);
            RuleFor(expression).Matches("[A-Z]*").WithMessage(msg);
        }

        /// <summary>
        /// The regla para correos.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="msg">
        /// The msg.
        /// </param>
        public void ruleForEmail(Expression<Func<T, string>> expression, string msg)
        {
            RuleFor(expression).NotEmpty().WithMessage(msg);
            RuleFor(expression).EmailAddress().WithMessage(msg);
        }

        /// <summary>
        /// The regla para campos nombres.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="msg">
        /// The msg.
        /// </param>
        public void ruleForNames(Expression<Func<T, string>> expression, string msg = "Bad name format")
        {
            RuleFor(expression).Matches(@".*[a-zA-Z]+(.*)").WithMessage(msg);
        }
    }
}
