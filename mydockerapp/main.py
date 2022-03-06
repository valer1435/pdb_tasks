from sklearn.linear_model import LogisticRegression
from sklearn.model_selection import train_test_split
from sklearn.metrics import roc_auc_score
from sklearn.multiclass import OneVsRestClassifier
import pandas as pd

def main():
    df = pd.read_csv('iris.csv')
    y = df['variety']
    X = df.drop(['variety'], axis=1)
    X_train, X_test, y_train, y_test = train_test_split(X, y)
    model = OneVsRestClassifier(LogisticRegression()).fit(X_train, y_train)
    y_pred = model.predict_proba(X_test)

    print(f"Roc-auc score: {roc_auc_score(y_test, y_pred, multi_class='ovo')}")


if __name__ == '__main__':
    main()
