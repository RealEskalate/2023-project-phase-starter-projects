interface problem {
    id: string;
    imgUrl: string;
    body: string;
}

interface Content {
    problem: problem[],

    solution: problem[],
    sessions: {
        id: string;
        icon: string;
        title: string;
        body: string;
    }[],
}



export const content: Content = {
    problem: [
        {
            id: "1",
            imgUrl: "/images/Rectangle-1.png",
            body: "Africa’s future depends on innovation. Transformative technologies can drive rapid economic growth and lift millions of people out of poverty. However, university computer science education is misaligned with global market needs and fails to incorporate practice-based learning, leaving students unable to apply their skills in real-world contexts.",
        },
        {
            id: "2",
            imgUrl: "/images/Rectangle-1.png",
            body: "With few global tech companies on the continent, aspiring engineers don’t have access to experienced mentors, or the opportunity to work on products that operate at scale. Smart and ambitious students who could create life-changing technologies aren’t able to reach their potential."
        },
    ],
    solution: [{ id: "1", imgUrl: "/images/Rectangle-1.png", body: "Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere." }],

    sessions: [
        {
            id: '0',
            icon: '/images/Ellipse-0.png',
            title: 'Bi-weekly contests',
            body: 'Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces.',
        },
        {
            id: '1',
            icon: '/images/Ellipse-1.png',
            title: 'Technical Training',
            body: '6 days a week, 3 hours of lectures and practice sessions to improve technical problem-solving skills.'
        },
        {
            id: '2',
            icon: '/images/Ellipse-2.png',
            title: 'Q&As',
            body: 'In Q&As, we get to know engineers, founders, and entrepreneurs from top tech companies. We see that they are normal people like us and we learn the best practices.'
        },
        {
            id: '3',
            icon: '/images/Ellipse-3.png',
            title: 'Problem Solving Sessions',
            body: 'We solve technical problems on a whiteboard while explaining to the class. It helps to get a feel of an interview environment.'
        },
        {
            id: '4',
            icon: '/images/Ellipse-4.png',
            title: 'Learning How To Approach',
            body: 'Students observe how an experienced problem solver approaches a problem from understanding it to implementing a working solution.'
        },
        {
            id: '5',
            icon: '/images/Ellipse-5.png',
            title: 'Bi-weekly 1:1s',
            body: 'In 1:1s, we can talk about anything that matters; clearly no boundaries. The more we speak our minds without a filter, the better for the team.'
        },


    ]
};