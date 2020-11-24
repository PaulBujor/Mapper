package dk.groupfive.ModeratorServer.model.objects;

public class Report<T> {
    private long reportId;
    private T reportedItem;
    private String reportedClass;
    private boolean resolved;

    private String category;
    private String description;

    public Report(T reportedItem) {
        this.reportedItem = reportedItem;
        reportedClass = reportedItem.getClass().getName();
    }

    public T getReportedItem() {
        return reportedItem;
    }

    public String getReportedClass() {
        return reportedClass;
    }

    public long getReportId() {
        return reportId;
    }

    public String getCategory() {
        return category;
    }

    public String getDescription() {
        return description;
    }
}
