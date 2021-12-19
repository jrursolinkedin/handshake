'''
Name: Jack Urso
Date: 5/04/2021 (DUE)
Class: CSC 364
Assignment: Bayesian Probability Implementation - Final Project

Question:
-  When looking at the time and weather, what is the probability of
   a homicide occurring?

Description:
- Given time and weather attributes for user, this program performs
  naive bayes to determine the probability of a homicide occurring.
  In addition, this program also does data analysis on all the different
  combinations within the dataset. This gives you an ideal on how the
  probability differs from the attribute values.
- Steps to Program:
  - Option 1:
    - Asks the user for the time and weather attributes. And, whether to
      print the values from the algorithm.
    - Reads the dataset.
    - Finds the necessary values to perform naive bayes.
  - Option 2:
    - Reads the dataset.
    - Populates every possible value with every column.
    - Populates all the values in each column.
    - Find the average probabilities of every random combination of
      attribute values.

References:
- https://gist.github.com/TejeshJadhav/aac97170a0b4f2bc30276880c36b5ea6
'''

# Imports.
import random

'''
Prints the probabilities for P(A), P(C|A), P(C), and P(A|C).
P(A) = Prior Probabilities
P(C|A) = Likelihood Probabilities
P(C) = Normalizing Constant
P(A|C) = Posterior Probabilities
       = (P(C|A)*P(A))/P(C) 
'''
def Print(inp_data, c1, c2, c1_count, c2_count, pxbyc1, pxbyc2, pprob1, pprob2, normal):
    print()
    print("Prior Probability, P(A): ")
    print("P(Homicide = true) = " + str(float(c1_count/730)))
    print("P(Homicide = false) = " + str(float(c2_count/730)))

    print()
    print("Likelihood Probabilities, P(C|A): ")
    for idx in range(0, len(inp_data)):
        if idx == 0:
            print("P(Month = " + str(inp_data[idx]) + " | Homicide = true) = " + str(float(c1[idx]/c1_count)))
            print("P(Month = " + str(inp_data[idx]) + " | Homicide = false) = " + str(float(c2[idx]/c2_count)))
        elif idx == 1:
            print("P(Day = " + str(inp_data[idx]) + " | Homicide = true) = " + str(float(c1[idx]/c1_count)))
            print("P(Day = " + str(inp_data[idx]) + " | Homicide = false) = " + str(float(c2[idx]/c2_count)))
        elif idx == 2:
            print("P(Time = " + str(inp_data[idx]) + " | Homicide = true) = " + str(float(c1[idx] / c1_count)))
            print("P(Time = " + str(inp_data[idx]) + " | Homicide = false) = " + str(float(c2[idx] / c2_count)))
        elif idx == 3:
            print("P(Holiday = " + str(inp_data[idx]) + " | Homicide = true) = " + str(float(c1[idx] / c1_count)))
            print("P(Holiday = " + str(inp_data[idx]) + " | Homicide = false) = " + str(float(c2[idx] / c2_count)))
        elif idx == 4:
            print("P(Temp = " + str(inp_data[idx]) + " | Homicide = true) = " + str(float(c1[idx]/c1_count)))
            print("P(Temp = " + str(inp_data[idx]) + " | Homicide = false) = " + str(float(c2[idx]/c2_count)))
        elif idx == 5:
            print("P(Humidity = " + str(inp_data[idx]) + " | Homicide = true) = " + str(float(c1[idx] / c1_count)))
            print("P(Humidity = " + str(inp_data[idx]) + " | Homicide = false) = " + str(float(c2[idx] / c2_count)))
        elif idx == 6:
            print("P(Wind = " + str(inp_data[idx]) + " | Homicide = true) = " + str(float(c1[idx] / c1_count)))
            print("P(Wind = " + str(inp_data[idx]) + " | Homicide = false) = " + str(float(c2[idx] / c2_count)))
        elif idx == 7:
            print("P(Weather = " + str(inp_data[idx]) + " | Homicide = true) = " + str(float(c1[idx] / c1_count)))
            print("P(Weather = " + str(inp_data[idx]) + " | Homicide = false) = " + str(float(c2[idx] / c2_count)))

    print()
    print("Normalizing Constant, P(C): ")
    print("P(C) = " + str(normal))

    print()
    print("Probabilities, P(C|A)*P(A): ")
    print("P(X | Homicide = true)*P(Homicide = true) = " + str(float(pxbyc1)))
    print("P(X | Homicide = false)*P(Homicide = false) = " + str(float(pxbyc2)))

    print()
    print("Posterior Model, P(A|C) = (P(C|A)*P(A))/P(C):")
    print("P(Homicide = true | X) = " + str(pprob1))
    print("P(Homicide = false | X) = " + str(pprob2))

'''
This function calculates all the above the values
that were printed out in the function above. Lastly,
it returns the posterior probabilities for 'true' and
'false' in an 2-item array [false,true].
'''
def NaiveBayes(inp, num):
    # Counters for "true" and "false"
    # for target attribute.
    c1_count = 0
    c2_count = 0

    # Counts for selected attributes.
    c1 = [0, 0, 0, 0, 0, 0, 0, 0]
    c2 = [0, 0, 0, 0, 0, 0, 0, 0]

    # Same as above but divided by number
    # of lines (rows in dataset).
    pc1 = [0, 0, 0, 0, 0, 0, 0, 0]
    pc2 = [0, 0, 0, 0, 0, 0, 0, 0]

    # Gets all the data from the dataset.
    data = []
    f = open("nbdata.csv", "r")
    d = f.read()
    lines = d.split("\n")
    for d in lines:
        data.append((d.split(",")))

    # Holds number of attributes.
    attrs = len(data[0])

    # Gets the counts for "c1_count"
    # and "c2_count".
    for i in range(len(lines)-1):
        if data[i][attrs-1].lower() == "true":
            c1_count = c1_count + 1
        if data[i][attrs-1].lower() == "false":
            c2_count = c2_count + 1

    # Gets probability for "true" and "false"
    # values in the target column. Or, it gives
    # Prior Probability, P(A).
    pofc1 = c1_count/(len(lines)-1)
    pofc2 = c2_count/(len(lines)-1)

    # User user for selected attributes.
    inp_data = inp.split(",")

    # Counts the number of times the selected
    # attribute shows up.
    for i in range(len(lines)-1):
        for j in range(attrs-1):
            if data[i][j].lower() == inp_data[j].lower():
                if data[i][attrs-1].lower() == "true":
                    c1[j] = c1[j] + 1
                else:
                    c2[j] = c2[j] + 1

    # This gives you the "Normalizing factor", P(C).
    normal = float(1)
    for y in range(0, len(inp_data)):
        normal = float(normal*float((c1[y]+c2[y])/(len(lines)-1)))

    # This gives "Likelyhood", P(C|A).
    pc1[:] = [x/c1_count for x in c1]
    pc2[:] = [x/c2_count for x in c2]
    pxbyc1 = 1
    pxbyc2 = 1
    for x in pc1:
        pxbyc1 = pxbyc1*x
    for x in pc2:
        pxbyc2 = pxbyc2*x

    # This gives P(C|A)*P(A).
    pxbyc1 = pxbyc1 * pofc1
    pxbyc2 = pxbyc2 * pofc2

    # This gives you posterior probability,
    # P(A|C) = (P(C|A)*P(A))/P(c)
    pprob1 = float(pxbyc1/normal)
    pprob2 = float(pxbyc2/normal)

    # Print information.
    if num == 1:
        Print(inp_data, c1, c2, c1_count, c2_count, pxbyc1, pxbyc2, pprob1, pprob2, normal)

    return [pprob2, pprob1]

'''
Main function.
'''
def main():

    option = 0

    # Running.
    if option == 1:
        # User user for selected attributes.
        inp = input("Enter Month, Day, Time, Holiday, Temp, Humidity, Wind, Weather to determine Whether a homicide occurs: ")
        NaiveBayes(str(inp), 1)
    # Testing (Data Analyzing).
    else:
        # Every possible value that showed up.
        monthV = ["jan", "feb", "march", "april", "may", "june", "july", "aug", "sept", "oct", "nov", "dec"]
        dayV = ["mon", "tues", "wed", "thur", "fri", "sat", "sun", "sun"]
        timeV = ["morning", "evening"]
        holidayV = ["true", "false"]
        tempV = ["cool", "med", "hot"]
        humidV = ["low", "med", "high"]
        windV = ["weak", "med", "strong"]
        weatherV = ["broken clouds", "few clouds", "fog", "haze", "heavy intensity rain", "light rain", "light snow", "mist", "moderate rain", "overcast clouds", "scattered clouds", "sky is clear", "snow"]

        # Get all the values from the dataset.
        month = list()
        day = list()
        time = list()
        holiday = list()
        temp = list()
        humid = list()
        wind = list()
        weather = list()
        # Gets all the data from the dataset.
        f = open("nbdata.csv", "r")
        d = f.read()
        lines = d.split("\n")
        for d in lines:
            data = list(d.split(","))
            if len(data) != 1:
                month.append(data[0])
                day.append(data[1])
                time.append(data[2])
                holiday.append(data[3])
                temp.append(data[4])
                humid.append(data[5])
                wind.append(data[6])
                weather.append(data[7])

        # Number of iterations.
        itNum = 500

        # Looks at the probability for random combinations.
        print("**********************")
        for mth in monthV:
            fValues = []
            tValues = []
            for i in range(0, itNum):
                values = NaiveBayes(mth + "," + day[random.randint(0, len(day) - 1)] + "," + time[
                        random.randint(0, len(time) - 1)] + "," + holiday[random.randint(0, len(holiday) - 1)] + "," + temp[
                        random.randint(0, len(temp) - 1)] + "," + humid[random.randint(0, len(humid) - 1)] + "," + wind[
                        random.randint(0, len(wind) - 1)] + "," + weather[random.randint(0, len(weather) - 1)], 0)
                fValues.append(values[0])
                tValues.append(values[1])
            print("When Month = " + mth + ": ")
            print("T: " + str(float(sum(tValues) / len(tValues))))
            print("F: " + str(float(sum(fValues)) / len(fValues)))
        print("**********************")

        print("**********************")
        for dy in dayV:
            fValues = []
            tValues = []
            for i in range(0, itNum):
                values = NaiveBayes(month[random.randint(0, len(month)-1)]+"," + dy + "," + time[
                        random.randint(0, len(time) - 1)] + "," + holiday[random.randint(0, len(holiday) - 1)] + "," + temp[
                        random.randint(0, len(temp) - 1)] + "," + humid[random.randint(0, len(humid) - 1)] + "," + wind[
                        random.randint(0, len(wind) - 1)] + "," + weather[random.randint(0, len(weather) - 1)], 0)
                fValues.append(values[0])
                tValues.append(values[1])
            print("When Day = " + dy + ": ")
            print("T: " + str(float(sum(tValues) / len(tValues))))
            print("F: " + str(float(sum(fValues)) / len(fValues)))
        print("**********************")

        print("**********************")
        for tm in timeV:
            fValues = []
            tValues = []
            for i in range(0, itNum):
                values = NaiveBayes(month[random.randint(0, len(month) - 1)] + "," + day[random.randint(0, len(day)-1)]
                                    + "," + tm + "," + holiday[random.randint(0, len(holiday) - 1)] + "," + temp[
                                        random.randint(0, len(temp) - 1)] + "," + humid[
                                        random.randint(0, len(humid) - 1)] + "," + wind[
                                        random.randint(0, len(wind) - 1)] + "," + weather[
                                        random.randint(0, len(weather) - 1)], 0)
                fValues.append(values[0])
                tValues.append(values[1])
            print("When Time = " + tm + ": ")
            print("T: " + str(float(sum(tValues) / len(tValues))))
            print("F: " + str(float(sum(fValues)) / len(fValues)))
        print("**********************")

        print("**********************")
        for hday in holidayV:
            fValues = []
            tValues = []
            for i in range(0, itNum):
                values = NaiveBayes(month[random.randint(0, len(month)-1)]+","+day[random.randint(0, len(day)-1)]+","+time[
                    random.randint(0, len(time)-1)]+","+hday+","+temp[
                    random.randint(0, len(temp)-1)]+","+humid[random.randint(0, len(humid)-1)]+","+wind[
                    random.randint(0, len(wind)-1)]+","+weather[random.randint(0, len(weather)-1)], 0)
                fValues.append(values[0])
                tValues.append(values[1])
            print("When Holiday = " + hday + ": ")
            print("T: " + str(float(sum(tValues)/len(tValues))))
            print("F: " + str(float(sum(fValues))/len(fValues)))
        print("**********************")

        print("**********************")
        for tp in tempV:
            fValues = []
            tValues = []
            for i in range(0, itNum):
                values = NaiveBayes(
                    month[random.randint(0, len(month) - 1)] + "," + day[random.randint(0, len(day) - 1)] + "," + time[
                        random.randint(0, len(time) - 1)] + "," + holiday[random.randint(0, len(holiday) - 1)] + "," + tp + "," + humid[random.randint(0, len(humid) - 1)] + "," + wind[
                        random.randint(0, len(wind) - 1)] + "," + weather[random.randint(0, len(weather) - 1)], 0)
                fValues.append(values[0])
                tValues.append(values[1])
            print("When Temp = " + tp + ": ")
            print("T: " + str(float(sum(tValues) / len(tValues))))
            print("F: " + str(float(sum(fValues)) / len(fValues)))
        print("**********************")

        print("**********************")
        for hum in humidV:
            fValues = []
            tValues = []
            for i in range(0, itNum):
                values = NaiveBayes(
                    month[random.randint(0, len(month) - 1)] + "," + day[random.randint(0, len(day) - 1)] + "," + time[
                        random.randint(0, len(time) - 1)] + "," + holiday[random.randint(0, len(holiday) - 1)] + "," + temp[
                        random.randint(0, len(temp) - 1)] + "," + hum + "," + wind[
                        random.randint(0, len(wind) - 1)] + "," + weather[random.randint(0, len(weather) - 1)], 0)
                fValues.append(values[0])
                tValues.append(values[1])
            print("When Humidity = " + hum + ": ")
            print("T: " + str(float(sum(tValues) / len(tValues))))
            print("F: " + str(float(sum(fValues)) / len(fValues)))
        print("**********************")

        print("**********************")
        for wd in windV:
            fValues = []
            tValues = []
            for i in range(0, itNum):
                values = NaiveBayes(
                    month[random.randint(0, len(month) - 1)] + "," + day[random.randint(0, len(day) - 1)] + "," + time[
                        random.randint(0, len(time) - 1)] + "," + holiday[random.randint(0, len(holiday) - 1)] + "," + temp[
                        random.randint(0, len(temp) - 1)] + "," + humid[random.randint(0, len(humid) - 1)] + "," + wd + "," + weather[random.randint(0, len(weather) - 1)], 0)
                fValues.append(values[0])
                tValues.append(values[1])
            print("When Wind = " + wd + ": ")
            print("T: " + str(float(sum(tValues) / len(tValues))))
            print("F: " + str(float(sum(fValues)) / len(fValues)))
        print("**********************")

        print("**********************")
        for weath in weatherV:
            fValues = []
            tValues = []
            for i in range(0, itNum):
                values = NaiveBayes(
                    month[random.randint(0, len(month) - 1)] + "," + day[random.randint(0, len(day) - 1)] + "," + time[
                        random.randint(0, len(time) - 1)] + "," + holiday[random.randint(0, len(holiday) - 1)] + "," +temp[
                        random.randint(0, len(temp) - 1)] + "," + humid[
                        random.randint(0, len(humid) - 1)] + "," + wind[random.randint(0, len(wind) - 1)] + "," + weath, 0)
                fValues.append(values[0])
                tValues.append(values[1])
            print("When Weather = " + weath + ": ")
            print("T: " + str(float(sum(tValues) / len(tValues))))
            print("F: " + str(float(sum(fValues)) / len(fValues)))
        print("**********************")



main()