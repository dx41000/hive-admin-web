namespace hive_admin_web.Components;

public class Helper
{
    public static (int newWidth, int newHeight) MaintainAspectRatio(int originalWidth, int originalHeight, int newWidth)
    {
        // Calculate the new height based on the new width
        int newHeight = (int)((double)originalHeight / originalWidth * newWidth);
        
        return (newWidth, newHeight);
    }
    
    public static (double newWidth, double newHeight) MaintainAspectRatioDouble(int originalWidth, int originalHeight, int newWidth)
    {
        // Calculate the new height based on the new width
        double newHeight = ((double)originalHeight / originalWidth * newWidth);
        
        return (newWidth, newHeight);
    }
    
    public static (int newWidthBaseArtwork, int newHeightBaseArtwork, int newWidthPrintBox, int newHeightPrintBox,
        int newTopBaseArtwork, int newLeftBaseArtwork, int newTopPrintBox, int newLeftPrintBox) 
        ScaleRectangles(
            int baseArtworkWidth, int baseArtworkHeight, int baseArtworkTop, int baseArtworkLeft,
            int printBoxWidth, int printBoxHeight, int printBoxTop, int printBoxLeft, 
            int targetBaseArtworkWidth)
    {
        // Calculate the scaling factor based on the target width for the baseArtwork rectangle
        double scaleFactor = (double)targetBaseArtworkWidth / baseArtworkWidth;

        // Calculate the new dimensions for the baseArtwork rectangle
        int newHeightBaseArtwork = (int)((double)baseArtworkHeight * scaleFactor);
        int newWidthBaseArtwork = targetBaseArtworkWidth;

        // Calculate the new dimensions for the printBox rectangle
        int newWidthPrintBox = (int)(printBoxWidth * scaleFactor);
        int newHeightPrintBox = (int)(printBoxHeight * scaleFactor);

        // Calculate the new positions (top-left) for the baseArtwork rectangle
        int newTopBaseArtwork = (int)(baseArtworkTop * scaleFactor);
        int newLeftBaseArtwork = (int)(baseArtworkLeft * scaleFactor);

        // Calculate the offset between the original baseArtwork and printBox
        int offsetTop = printBoxTop - baseArtworkTop;
        int offsetLeft = printBoxLeft - baseArtworkLeft;

        // Calculate the new positions (top-left) for the printBox relative to the new baseArtwork position
        int newTopPrintBox = (int)(offsetTop * scaleFactor);
        int newLeftPrintBox = (int)(offsetLeft * scaleFactor);

        return (
            newWidthBaseArtwork, 
            newHeightBaseArtwork, 
            newWidthPrintBox, 
            newHeightPrintBox,
            newTopBaseArtwork, 
            newLeftBaseArtwork, 
            newTopPrintBox, 
            newLeftPrintBox);
    }
}