import { fetchItems } from '../utils/umbracoContentDeliveryApi';
import Link from 'next/link'
import styles from './listing.module.css';

import Head from 'next/head';

const Listing = (props) => {
    const { blogPages } = props;

    return (
        <>
        <Head>
            <title>Listing</title>
        </Head>
        <div class="hero">
            <div class="container">
                <h1>
                    Blog Listing Page
                </h1>
            </div>
        </div>
        <section className="container content">
            <div>
                {blogPages.map((blogpage) => {

                    return (
                        <div className={styles.listing}>
                            <Link href={blogpage.route.path}>
                                {blogpage.name}
                            </Link>
                        </div>);
                })}
            </div>
        </section>
        </>
    )
}

export async function getServerSideProps() {
    const blogPages = await fetchItems({filter:'blog'});
    console.log('blogPages', blogPages);

    return {
        props: {
            blogPages: blogPages.items
        }
    }

}

export default Listing;
