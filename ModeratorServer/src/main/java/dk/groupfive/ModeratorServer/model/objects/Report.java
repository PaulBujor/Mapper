package dk.groupfive.ModeratorServer.model.objects;

import dk.groupfive.ModeratorServer.model.Model;

public class Report<T> {
    private long reportID;
    private T reportedItem;
    private String reportedClass;

    private String reportCategory;
    private String reportName;
    private String reportDescription;

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

    public long getReportID() {
        return reportID;
    }

    public String getReportCategory() {
        return reportCategory;
    }

    public String getReportName() {
        return reportName;
    }

    public String getReportDescription() {
        return reportDescription;
    }
}
