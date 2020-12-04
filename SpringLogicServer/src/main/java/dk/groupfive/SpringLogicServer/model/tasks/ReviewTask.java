package dk.groupfive.SpringLogicServer.model.tasks;

import dk.groupfive.SpringLogicServer.model.objects.ReviewItem;

public class ReviewTask {
    private String taskName;
    private long id;
    private ReviewItem reviewItem;

    public ReviewTask(String taskName, long id) {
        this.taskName = taskName;
        this.id = id;
    }

    public ReviewTask(String taskName, ReviewItem reviewItem) {
        this.taskName = taskName;
        this.reviewItem = reviewItem;
    }

    public ReviewTask(String taskName, long id, ReviewItem reviewItem) {
        this.taskName = taskName;
        this.id = id;
        this.reviewItem = reviewItem;
    }

    public String getTaskName() {
        return taskName;
    }

    public long getId() {
        return id;
    }

    public ReviewItem getReviewItem() {
        return reviewItem;
    }
}
