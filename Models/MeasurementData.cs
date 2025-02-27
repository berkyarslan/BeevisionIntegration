namespace BeeVision_Integration.Models
{
    public class MeasurementData
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string DimWt { get; set; }
        public string RealVolume { get; set; }
        public string Weight { get; set; }
        public string UnitID { get; set; }
        public string BranchID { get; set; }
        public string Barcode { get; set; }
        public string BarcodeType { get; set; }
        public string BarcodeSource { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string MeasurementID { get; set; }
        public string ImageBase64 { get; set; }
        public string SerialNumber { get; set; }
        public string DimUnit { get; set; }
        public string WeightUnit { get; set; }
        public int IsRegular { get; set; }
        public string ObjectRGBCoordinates { get; set; }
        public string Operator { get; set; }
        public string Reserved1 { get; set; }
        public string CRC { get; set; }

        // commit
    }
}
