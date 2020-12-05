package dk.groupfive.SpringLogicServer.model.tasks;

import dk.groupfive.SpringLogicServer.model.objects.Review;
import dk.groupfive.SpringLogicServer.model.objects.obsolete.ReviewItem;

public class ReviewTask {
    private String taskName;
    private long id;
    private Review reviewItem;

    public ReviewTask(String taskName, long id) {
        this.taskName = taskName;
        this.id = id;
    }

    public ReviewTask(String taskName, Review reviewItem) {
        this.taskName = taskName;
        this.reviewItem = reviewItem;
    }

    public ReviewTask(String taskName, long id, Review reviewItem) {
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

    public Review getReviewItem() {
        return reviewItem;
    }
}
