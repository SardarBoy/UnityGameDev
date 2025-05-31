import pandas as pd
import numpy as np
from sklearn.cluster import KMeans
from sklearn.preprocessing import StandardScaler
import matplotlib.pyplot as plt
import seaborn as sns

# Load data
df = pd.read_csv("session_data.csv")
features = ['accuracy', 'reaction_time']

# Scale features
scaler = StandardScaler()
X_scaled = scaler.fit_transform(df[features])

# Elbow method to find optimal clusters
sse = []
for k in range(1, 10):
    km = KMeans(n_clusters=k, random_state=42)
    km.fit(X_scaled)
    sse.append(km.inertia_)

plt.figure(figsize=(8, 5))
plt.plot(range(1, 10), sse, marker='o')
plt.title('Elbow Method for Optimal k')
plt.xlabel('Number of clusters')
plt.ylabel('SSE')
plt.grid(True)
plt.savefig("elbow_plot.png")
plt.close()

# Final clustering
kmeans = KMeans(n_clusters=3, random_state=42)
df['cluster'] = kmeans.fit_predict(X_scaled)

# Summary stats
cluster_summary = df.groupby('cluster')[features].mean()
print("Cluster summaries:")
print(cluster_summary)

# Plot clusters
plt.figure(figsize=(8, 6))
sns.scatterplot(data=df, x='accuracy', y='reaction_time', hue='cluster', palette='viridis')
plt.title('Player Clustering')
plt.xlabel('Accuracy')
plt.ylabel('Reaction Time')
plt.legend(title='Cluster')
plt.grid(True)
plt.savefig("player_clusters.png")
plt.close()

# Save labeled data
df.to_csv("labeled_sessions.csv", index=False)
print("Clustered data saved to labeled_sessions.csv")