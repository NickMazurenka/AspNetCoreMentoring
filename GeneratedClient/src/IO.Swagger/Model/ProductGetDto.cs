/* 
 * NorthwindTraders API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// ProductGetDto
    /// </summary>
    [DataContract]
    public partial class ProductGetDto :  IEquatable<ProductGetDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGetDto" /> class.
        /// </summary>
        /// <param name="productId">productId.</param>
        /// <param name="productName">productName.</param>
        /// <param name="categoryId">categoryId.</param>
        /// <param name="quantityPerUnit">quantityPerUnit.</param>
        /// <param name="unitPrice">unitPrice.</param>
        /// <param name="unitsInStock">unitsInStock.</param>
        /// <param name="unitsOnOrder">unitsOnOrder.</param>
        /// <param name="reorderLevel">reorderLevel.</param>
        /// <param name="discontinued">discontinued.</param>
        /// <param name="category">category.</param>
        public ProductGetDto(int? productId = default(int?), string productName = default(string), int? categoryId = default(int?), string quantityPerUnit = default(string), double? unitPrice = default(double?), int? unitsInStock = default(int?), int? unitsOnOrder = default(int?), int? reorderLevel = default(int?), bool? discontinued = default(bool?), CategoryGetDto category = default(CategoryGetDto))
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.CategoryId = categoryId;
            this.QuantityPerUnit = quantityPerUnit;
            this.UnitPrice = unitPrice;
            this.UnitsInStock = unitsInStock;
            this.UnitsOnOrder = unitsOnOrder;
            this.ReorderLevel = reorderLevel;
            this.Discontinued = discontinued;
            this.Category = category;
        }
        
        /// <summary>
        /// Gets or Sets ProductId
        /// </summary>
        [DataMember(Name="productId", EmitDefaultValue=false)]
        public int? ProductId { get; set; }

        /// <summary>
        /// Gets or Sets ProductName
        /// </summary>
        [DataMember(Name="productName", EmitDefaultValue=false)]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or Sets CategoryId
        /// </summary>
        [DataMember(Name="categoryId", EmitDefaultValue=false)]
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or Sets QuantityPerUnit
        /// </summary>
        [DataMember(Name="quantityPerUnit", EmitDefaultValue=false)]
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Gets or Sets UnitPrice
        /// </summary>
        [DataMember(Name="unitPrice", EmitDefaultValue=false)]
        public double? UnitPrice { get; set; }

        /// <summary>
        /// Gets or Sets UnitsInStock
        /// </summary>
        [DataMember(Name="unitsInStock", EmitDefaultValue=false)]
        public int? UnitsInStock { get; set; }

        /// <summary>
        /// Gets or Sets UnitsOnOrder
        /// </summary>
        [DataMember(Name="unitsOnOrder", EmitDefaultValue=false)]
        public int? UnitsOnOrder { get; set; }

        /// <summary>
        /// Gets or Sets ReorderLevel
        /// </summary>
        [DataMember(Name="reorderLevel", EmitDefaultValue=false)]
        public int? ReorderLevel { get; set; }

        /// <summary>
        /// Gets or Sets Discontinued
        /// </summary>
        [DataMember(Name="discontinued", EmitDefaultValue=false)]
        public bool? Discontinued { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [DataMember(Name="category", EmitDefaultValue=false)]
        public CategoryGetDto Category { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProductGetDto {\n");
            sb.Append("  ProductId: ").Append(ProductId).Append("\n");
            sb.Append("  ProductName: ").Append(ProductName).Append("\n");
            sb.Append("  CategoryId: ").Append(CategoryId).Append("\n");
            sb.Append("  QuantityPerUnit: ").Append(QuantityPerUnit).Append("\n");
            sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
            sb.Append("  UnitsInStock: ").Append(UnitsInStock).Append("\n");
            sb.Append("  UnitsOnOrder: ").Append(UnitsOnOrder).Append("\n");
            sb.Append("  ReorderLevel: ").Append(ReorderLevel).Append("\n");
            sb.Append("  Discontinued: ").Append(Discontinued).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ProductGetDto);
        }

        /// <summary>
        /// Returns true if ProductGetDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ProductGetDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProductGetDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ProductId == input.ProductId ||
                    (this.ProductId != null &&
                    this.ProductId.Equals(input.ProductId))
                ) && 
                (
                    this.ProductName == input.ProductName ||
                    (this.ProductName != null &&
                    this.ProductName.Equals(input.ProductName))
                ) && 
                (
                    this.CategoryId == input.CategoryId ||
                    (this.CategoryId != null &&
                    this.CategoryId.Equals(input.CategoryId))
                ) && 
                (
                    this.QuantityPerUnit == input.QuantityPerUnit ||
                    (this.QuantityPerUnit != null &&
                    this.QuantityPerUnit.Equals(input.QuantityPerUnit))
                ) && 
                (
                    this.UnitPrice == input.UnitPrice ||
                    (this.UnitPrice != null &&
                    this.UnitPrice.Equals(input.UnitPrice))
                ) && 
                (
                    this.UnitsInStock == input.UnitsInStock ||
                    (this.UnitsInStock != null &&
                    this.UnitsInStock.Equals(input.UnitsInStock))
                ) && 
                (
                    this.UnitsOnOrder == input.UnitsOnOrder ||
                    (this.UnitsOnOrder != null &&
                    this.UnitsOnOrder.Equals(input.UnitsOnOrder))
                ) && 
                (
                    this.ReorderLevel == input.ReorderLevel ||
                    (this.ReorderLevel != null &&
                    this.ReorderLevel.Equals(input.ReorderLevel))
                ) && 
                (
                    this.Discontinued == input.Discontinued ||
                    (this.Discontinued != null &&
                    this.Discontinued.Equals(input.Discontinued))
                ) && 
                (
                    this.Category == input.Category ||
                    (this.Category != null &&
                    this.Category.Equals(input.Category))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ProductId != null)
                    hashCode = hashCode * 59 + this.ProductId.GetHashCode();
                if (this.ProductName != null)
                    hashCode = hashCode * 59 + this.ProductName.GetHashCode();
                if (this.CategoryId != null)
                    hashCode = hashCode * 59 + this.CategoryId.GetHashCode();
                if (this.QuantityPerUnit != null)
                    hashCode = hashCode * 59 + this.QuantityPerUnit.GetHashCode();
                if (this.UnitPrice != null)
                    hashCode = hashCode * 59 + this.UnitPrice.GetHashCode();
                if (this.UnitsInStock != null)
                    hashCode = hashCode * 59 + this.UnitsInStock.GetHashCode();
                if (this.UnitsOnOrder != null)
                    hashCode = hashCode * 59 + this.UnitsOnOrder.GetHashCode();
                if (this.ReorderLevel != null)
                    hashCode = hashCode * 59 + this.ReorderLevel.GetHashCode();
                if (this.Discontinued != null)
                    hashCode = hashCode * 59 + this.Discontinued.GetHashCode();
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
