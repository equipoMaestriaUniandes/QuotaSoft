namespace Quota.Domain.Entities.Enums
{
    /// <summary>
    /// Tipo Metodo
    /// </summary>
    public enum TypeMethodEnum
    {
        /// <summary>
        /// The solo lectura
        /// </summary>
        ReadOnly,
        /// <summary>
        /// The acceso total
        /// </summary>
        Write,
        /// <summary>
        /// The cualquiera
        /// </summary>
        ReadAndWrite,
        /// <summary>
        /// The cualquiera
        /// </summary>
        GraphQL
    }
}
