import BlogCard from "./BlogCard"

const Blogs = () => {
  let n = [1,2,3,5,6,7,8]

  return (
    <div className="py-8 gap-12 flex flex-col items-center md:grid md:grid-cols-2 xl:grid-cols-4">
        {n.map((_) => <BlogCard/>)}
    </div>
  )
}

export default Blogs