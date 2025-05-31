import pandas as pd
import numpy as np
from sklearn.linear_model import LogisticRegression
from sklearn.model_selection import train_test_split, cross_val_score
from sklearn.preprocessing import StandardScaler
from sklearn.pipeline import Pipeline
from sklearn.metrics import classification_report, confusion_matrix
import joblib

# Load and inspect the data
df = pd.read_csv("session_data.csv")
print("Initial data shape:", df.shape)
print(df.head())

# Feature engineering
df['accuracy_bucket'] = pd.cut(df['accuracy'], bins=[0, 0.5, 0.75, 0.9, 1.0], labels=[0, 1, 2, 3])
df['reaction_fast'] = (df['reaction_time'] < 0.3).astype(int)

# Target variable
def categorize(row):
    if row['accuracy'] > 0.9 and row['reaction_time'] < 0.3:
        return 'Extreme'
    elif row['accuracy'] > 0.75:
        return 'Hard'
    elif row['accuracy'] > 0.5:
        return 'Medium'
    else:
        return 'Easy'

df['difficulty'] = df.apply(categorize, axis=1)

# Feature and label prep
X = df[['accuracy', 'reaction_time', 'reaction_fast']]
y = df['difficulty']

# Pipeline with scaling
pipeline = Pipeline([
    ('scaler', StandardScaler()),
    ('classifier', LogisticRegression(max_iter=1000, multi_class='multinomial'))
])

# Train-test split
X_train, X_test, y_train, y_test = train_test_split(X, y, stratify=y, random_state=42)

# Training
pipeline.fit(X_train, y_train)

# Evaluation
y_pred = pipeline.predict(X_test)
print("Classification Report:")
print(classification_report(y_test, y_pred))
print("Confusion Matrix:")
print(confusion_matrix(y_test, y_pred))

# Save model
joblib.dump(pipeline, "difficulty_model.pkl")
print("Model saved to difficulty_model.pkl")