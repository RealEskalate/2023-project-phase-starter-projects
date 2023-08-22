
const page = () => {
  return (
    <main className="container">
        <div className="container lg:max-w-screen-xl mx-auto grid grid-cols-12  gap-4">
            <div className="col-span-8">
                main section
            </div>
            <div className="col-span-4">
                sidebar
            </div>
        </div>
    </main>
  )
}

export default page