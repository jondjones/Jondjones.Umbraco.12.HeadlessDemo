import { fetchItem, fetchItems } from '../utils/umbracoContentDeliveryApi';
import Image from 'next/image'

const NewsPage = (props) => {

    const {name, properties} = props;
    const imageUrl ='https://localhost:44351' + properties?.image[0]?.url
    console.log(props, imageUrl)

    return (
        <>
            <div className="hero">
                <div className="container">
                    <h1>
                        {name}
                    </h1>
                </div>
            </div>
            <section className="container content">
                {properties?.contentArea}

                <img src={imageUrl} alt={properties?.image[0]?.name} />

                <Image
                    src={imageUrl}
                    alt={properties?.image[0]?.name}
                    width={properties?.image[0]?.width}
                    height={properties?.image[0]?.height}
                    unoptimized={true}
                />
            </section>
        </>
    )
}

export async function getStaticPaths() {

    const blogPages = await fetchItems({filter:'blog'});
    const paths = blogPages.items.map(item => item.route.path);
    console.log(paths)
    return {
        paths,
        fallback: false
    }
}

export async function getStaticProps({params}) {

    const blogPage = await fetchItem(params.blog);

    return {
        props: blogPage
    }
}

export default NewsPage;