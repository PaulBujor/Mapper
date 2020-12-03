package dk.groupfive.SpringLogicServer.model.objects;

public class Report<T> {
    private long reportId;
    private T reportedItem;
    private String reportedClass;
    private boolean resolved;

    private String category;
    private String description;

    /*for json to serialize the object*/

    public Report() {
    }

    public Report(T reportedItem) {
        this.reportedItem = reportedItem;
        reportedClass = reportedItem.getClass().getName();
    }

    public Report(T reportedItem, String category, String description) {
        this.reportedItem = reportedItem;
        reportedClass = reportedItem.getClass().getName();
        this.category = category;
        this.description = description;
        resolved = false;
    }

    public void setResolved(boolean resolved) {
        this.resolved = resolved;
    }

    public long getReportId() {
        return reportId;
    }

    public T getReportedItem() {
        return reportedItem;
    }

    public String getReportedClass() {
        return reportedClass;
    }

    public boolean isResolved() {
        return resolved;
    }

    public String getCategory() {
        return category;
    }

    public String getDescription() {
        return description;
    }
}
