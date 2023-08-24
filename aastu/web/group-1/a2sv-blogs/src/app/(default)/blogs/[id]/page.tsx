import Image from "next/image";

const Blog = ({ params }: { params: { id: string } }) => {
  // Sample blog object, fetched from the backend
  const obj = {
    _id: "64dfe9dd50d83607285ffa10",
    image:
      "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
    title: "Mastering the Art of Code Refactoring 2",
    description:
      "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
    author: {
      _id: "64dfe6fb50961c55ce93e7de",
      name: "Bruk Mekonen",
      email: "bruk@gmail.com",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
      role: "user",
    },
    isPending: true,
    tags: ["Programming", "Code"],
    likes: 0,
    relatedBlogs: [],
    skills: ["Web Development", "Mobile"],
    createdAt: "2023-08-18T21:59:57.206Z",
    updatedAt: "2023-08-18T21:59:57.206Z",
    __v: 0,
  };

  return (
    <div className="p-20 flex flex-col items-center gap-10">
      <div className="flex flex-col items-center gap-4">
        <h1 className="text-3xl font-french">{obj.title}</h1>
        <p className="font-montserrat uppercase text-xs text-center">
          {obj.tags.map((tag, index) =>
            index != obj.tags.length - 1 ? `${tag}, ` : tag
          )}
        </p>
      </div>
      <Image src={obj.image} alt="blog image" width={1000} height={450} />
      <div className="flex flex-col items-center gap-2">
        <Image
          src={obj.author.image}
          alt="author image"
          width={50}
          height={50}
          className="rounded-full"
        />
        <p className="font-montserrat uppercase text-xs">{obj.author.name}</p>
      </div>
      <div className="md:px-32 flex flex-col gap-8 text-justify py-4">
        <div>
          <p className="font-montserrat text-lg font-bold">{obj.description}</p>
        </div>
        {obj.description.split("\n").map((paragraph, index) => (
          <p key={index} className="font-montserrat text-sm">
            {paragraph}
          </p>
        ))}
      </div>
      <div className="text-left w-full flex flex-col gap-12">
        <h1 className="font-montserrat text-xl font-bold">Related Blogs</h1>
        <div className="flex gap-4 flex-wrap">
          {obj.relatedBlogs.length > 0 &&
            obj.relatedBlogs.map((blog, index) => (
              <div key={index} className="flex flex-col items-center gap-4">
                <Image
                  src={blog.image}
                  alt="blog image"
                  width={300}
                  height={200}
                />
                <p className="font-montserrat text-sm">{blog.title}</p>
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default Blog;
