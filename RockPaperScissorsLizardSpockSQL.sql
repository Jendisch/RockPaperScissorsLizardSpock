SELECT * FROM RPSLS_Table

SELECT DISTINCT Player_Name, Count(Wins) Total_Wins
FROM RPSLS_Table
GROUP BY Player_Name
ORDER BY Total_Wins DESC