import mediapipe as mp
import cv2

def get_tracking_data():
    """
    Captures webcam feed and uses MediaPipe to track face, pose, and hand landmarks in real-time.

    Yields:
        A dictionary containing face, pose, left hand, and right hand landmarks for each frame.
    """
    mp_drawing = mp.solutions.drawing_utils
    mp_holistic = mp.solutions.holistic
    mp_face_mesh = mp.solutions.face_mesh

    cap = cv2.VideoCapture(0)  # Initialize webcam

    with mp_holistic.Holistic(min_detection_confidence=0.5, min_tracking_confidence=0.5) as holistic:
        while cap.isOpened():
            ret, frame = cap.read()
            if not ret:
                print("Failed to grab frame.")
                break
            
            # Recolor Feed
            image = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
            # Make Detections
            results = holistic.process(image)

            # Prepare tracking data for this frame
            tracking_data = {
                "face_landmarks": results.face_landmarks,
                "pose_landmarks": results.pose_landmarks,
                "left_hand_landmarks": results.left_hand_landmarks,
                "right_hand_landmarks": results.right_hand_landmarks,
            }

            # Recolor image back to BGR for rendering
            image = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
            
            # Draw face landmarks
            if results.face_landmarks:
                mp_drawing.draw_landmarks(image, results.face_landmarks, mp_face_mesh.FACEMESH_CONTOURS)

            # Draw hand landmarks
            if results.right_hand_landmarks:
                mp_drawing.draw_landmarks(image, results.right_hand_landmarks, mp_holistic.HAND_CONNECTIONS)
            if results.left_hand_landmarks:
                mp_drawing.draw_landmarks(image, results.left_hand_landmarks, mp_holistic.HAND_CONNECTIONS)

            # Draw pose landmarks
            if results.pose_landmarks:
                mp_drawing.draw_landmarks(image, results.pose_landmarks, mp_holistic.POSE_CONNECTIONS)

            # Display the feed
            cv2.imshow('Raw Webcam Feed', image)

            # Yield the current frame's tracking data
            yield tracking_data

            # Exit loop on 'q' key press
            if cv2.waitKey(10) & 0xFF == ord('q'):
                break

    cap.release()
    cv2.destroyAllWindows()

if __name__ == "__main__":
    for frame_data in get_tracking_data():
        # Example: Print face landmarks in real-time
        if frame_data["face_landmarks"]:
            print(frame_data["face_landmarks"])
