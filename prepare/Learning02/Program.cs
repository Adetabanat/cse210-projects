// Create job instances
        Job job1 = new Job();
        job1._company = "Apple";
        job1._jobTitle = "Software Developer";
        job1._startYear = 2015;
        job1._endYear = 2019;

        Job job2 = new Job();
        job2._company = "Microsoft";
        job2._jobTitle = "Research analysist";
        job2._startYear = 2019;
        job2._endYear = 2023;

        // Create resume instance and add jobs
        Resume myResume = new Resume();
        myResume._name = "Damian Adongo";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the resume
        myResume.Display();