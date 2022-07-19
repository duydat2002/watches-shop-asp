using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace BTL1
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = (int)Session["userID"];

            if (userID == -1)
            {
                Response.Redirect("Home.aspx");
            }

            List<User> listUser = (List<User>)Application["listUser"];
            List<Contact> listContact = (List<Contact>)Application["listContact"];

            int indexUser = -1;
            for (int i=0; i<listUser.Count; i++)
            {
                if (listUser[i].Id == userID)
                {
                    indexUser = i;
                }
            }

            if (IsPostBack)
            {
                if (Request.Form["editProfile"] != null)
                {
                    bool checkTrung = false;

                    for (int i=0; i<listUser.Count; i++)
                    {
                        if (listUser[i].Id != int.Parse(Request.Form["editProfile"]) && listUser[i].Email == Request.Form["email"])
                        {
                            profileMessage_box.InnerHtml = "<span class='alert-server alert-server-error'>The email is already used.</span>";
                            checkTrung = true;
                            break;
                        }
                    }

                    if (!checkTrung)
                    {
                        profileMessage_box.InnerHtml = "<span class='alert-server alert-server-success'>Profile successfully updated.</span>";

                        listUser[indexUser].Firstname = Request.Form["firstname"];
                        listUser[indexUser].Lastname = Request.Form["lastname"];
                        listUser[indexUser].Email = Request.Form["email"];
                        listUser[indexUser].Birthdate = Request.Form["birthdate"];
                        listUser[indexUser].Sex = Request.Form["sex"] == "male" ? true : false;

                        Session["userName"] = $"{listUser[indexUser].Firstname} {listUser[indexUser].Lastname}";

                        XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                        FileStream file = File.Create(Server.MapPath("listUser.xml"));
                        xml.Serialize(file, listUser);
                        file.Close();
                    }
                }

                contactMessage_box.InnerHtml = "";

                if (Request.Form["saveContact"] != null)
                {
                    int orderNumberContact = 0;
                    bool checkTrung = false;
                    foreach (Contact ct in listContact)
                    {
                        if (ct.IdUser == userID)
                        {
                            orderNumberContact = ct.OrderNumber;
                            if (ct.PhoneNumber == Request.Form["phonenumber"] && ct.Address == Request.Form["address"])
                            {
                                contactMessage_box.InnerHtml = $@"<span class='alert-server alert-server-error'>This contact already exists.</span>";
                                checkTrung = true;
                                break;
                            }
                        }
                    }

                    if (!checkTrung)
                    {
                        Contact ct = new Contact(
                            userID,
                            orderNumberContact + 1,
                            Request.Form["phonenumber"],
                            Request.Form["address"],
                            orderNumberContact == 0 ? true : false
                        );
                        listContact.Add(ct);

                        XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
                        FileStream file = File.Create(Server.MapPath("listContact.xml"));
                        xml.Serialize(file, listContact);
                        file.Close();
                    }
                }

                if (Request.Form["editContact"] != null)
                {
                    int indexEdit = -1;
                    bool checkTrung = false;
                    for (int i=0; i<listContact.Count; i++)
                    {
                        if (listContact[i].IdUser == userID && listContact[i].OrderNumber != int.Parse(Request.Form["ordernumber"]) && listContact[i].PhoneNumber == Request.Form["phonenumber"] && listContact[i].Address == Request.Form["address"])
                        {
                            contactMessage_box.InnerHtml = "<span class='alert-server alert-server-error'>This contact already exists.</span>";
                            checkTrung = true;
                            break;
                        }  

                        if (listContact[i].IdUser == userID && listContact[i].OrderNumber == int.Parse(Request.Form["ordernumber"]))
                        {
                            indexEdit = i;
                        }
                    }

                    if (!checkTrung && indexEdit != -1)
                    {
                        contactMessage_box.InnerHtml = "<span class='alert-server alert-server-success'>Contact successfully updated.</span>";

                        listContact[indexEdit].PhoneNumber = Request.Form["phonenumber"];
                        listContact[indexEdit].Address = Request.Form["address"];

                        XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
                        FileStream file = File.Create(Server.MapPath("listContact.xml"));
                        xml.Serialize(file, listContact);
                        file.Close();
                    }
                }

                if (Request.Form["delete"] != null)
                {
                    foreach (Contact ct in listContact)
                    {
                        if (ct.IdUser == userID && ct.OrderNumber == int.Parse(Request.Form["delete"]))
                        {
                            listContact.Remove(ct);
                            break;
                        }
                    }

                    XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
                    FileStream file = File.Create(Server.MapPath("listContact.xml"));
                    xml.Serialize(file, listContact);
                    file.Close();
                }

                if (Request.Form["default"] != null)
                {
                    foreach (Contact ct in listContact)
                    {
                        if (ct.IdUser == userID)
                        {
                            if (ct.OrderNumber == int.Parse(Request.Form["default"]))
                                ct.IsDefault = true;
                            else
                                ct.IsDefault = false;
                        }
                    }

                    XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
                    FileStream file = File.Create(Server.MapPath("listContact.xml"));
                    xml.Serialize(file, listContact);
                    file.Close();
                }

                if (Request.Form["changePassword"] != null)
                {
                    if (listUser[indexUser].Password == Request.Form["password"])
                    {
                        passwordMessage_box.InnerHtml = "<span class='alert-server alert-server-success'>Password successfully updated.</span>";

                        listUser[indexUser].Password = Request.Form["newpassword"];

                        XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                        FileStream file = File.Create(Server.MapPath("listUser.xml"));
                        xml.Serialize(file, listUser);
                        file.Close();
                    }
                    else
                    {
                        passwordMessage_box.InnerHtml = "<span class='alert-server alert-server-error'>Wrong password.</span>";
                    }
                }
            }

            profileForm.InnerHtml = renderProfile(listUser[indexUser]);
            contact_list.InnerHtml = renderContact(listContact, userID);
        }

        protected string renderProfile(User us)
        {
            return $@" 
                <div class='form-group'>
                    <div class='flex ai-center'>
                        <label class='form-label'>First name</label>
                        <div class='form-input-box'>
                            <input class='form-control' name='firstname' id='firstname' type='text' value='{us.Firstname}'>
                        </div>
                    </div>
                    <div class='flex'>
                        <div class='form-label'></div>
                        <span class='form-error' id='firstname_error'></span>
                    </div>
                </div>
                <div class='form-group'>
                    <div class='flex ai-center'>
                        <label class='form-label'>Last name</label>
                        <div class='form-input-box'>
                            <input class='form-control' name='lastname' id='lastname' type='text' value='{us.Lastname}'>
                        </div>
                    </div>
                    <div class='flex'>
                        <div class='form-label'></div>
                        <span class='form-error' id='lastname_error'></span>
                    </div>
                </div>
                <div class='form-group'>
                    <div class='flex ai-center'>
                        <label class='form-label'>Email</label>
                        <div class='form-input-box'>
                            <input class='form-control' name='email' id='email' type='text' value='{us.Email}'>
                        </div>
                    </div>
                    <div class='flex'>
                        <div class='form-label'></div>
                        <span class='form-error' id='email_error'></span>
                    </div>
                </div>
                <div class='form-group'>
                    <div class='flex ai-center'>
                        <label class='form-label'>Birthdate</label>
                        <div class='form-input-box'>
                            <input class='form-control' name='birthdate' type='date' id='birthdate' value='{us.Birthdate}'>
                        </div>
                    </div>
                    <div class='flex'>
                        <div class='form-label'></div>
                        <span class='form-error' id='birthdate_error'></span>
                    </div>
                </div>
                <div class='form-group social-group'>
                    <div class='flex ai-center'>
                        <label class='form-label'>Social title</label>
                        <div class='form-input-box'>
                            {(us.Sex == true ? 
                            $@" <input class='form-social' name='sex' id='social-male' type='radio' value='male' checked>
                                <label for='social-male'> Mr</label>
                                <input class='form-social' name='sex' id='social-female' type='radio' value='female'>
                                <label for='social-female'> Mrs</label>" :
                            $@" <input class='form-social' name='sex' id='social-male' type='radio' value='male'>
                                <label for='social-male'> Mr</label>
                                <input class='form-social' name='sex' id='social-female' type='radio' value='female' checked>
                                <label for='social-female'> Mrs</label>")}
                        </div>
                    </div>
                </div>
                <button type='submit' name='editProfile' value='{us.Id}' class='button button-gb sign-btn' formaction='Account.aspx?tab=profile' onclick='return validateProfile()'>Update</button>
                <p class='form-text-bottom'>Have a good day <3</p>
            ";
        }

        protected string renderContact(List<Contact> listContact, int userID)
        {
            string htmls = "";
            bool checkEmty = true;
            
            foreach (Contact ct in listContact)
            {
                if (ct.IdUser == userID)
                {
                    checkEmty = false;
                    htmls += $@"
                        <div class='contact-item flex ai-center'>
                            <div class='col-9 col-sm-12'>
                                <div class='contact__content'>
                                    <div class='contact-row flex'>
                                        <span class='contact__label pd-gap'>Phone number</span>
                                        <span class='contact__desc pd-gap'>{ct.PhoneNumber}</span>
                                    </div>
                                    <div class='contact-row flex'>
                                        <span class='contact__label pd-gap'>Address</span>
                                        <span class='contact__desc pd-gap'>{ct.Address}</span>
                                    </div>
                                </div>
                            </div>
                            <div class='col-3 col-sm-12'>
                                <div class='contact__btns'>
                                    {(ct.IsDefault == true ?
                                    $@"<div class='contact-row'>
                                            <a href='Account.aspx?tab=contact&ordernumber={ct.OrderNumber}&phonenumber={ct.PhoneNumber}&address={ct.Address}' 
                                            class='contact-edit'>Edit</a>
                                        </div>
                                        <button type='button' class='contact-setdefault button button-gb button-disable'>Set as default</button>" :
                                    $@"<div class='contact-row'>
                                            <a href='Account.aspx?tab=contact&ordernumber={ct.OrderNumber}&phonenumber={ct.PhoneNumber}&address={ct.Address}' 
                                            class='contact-edit'>Edit</a>
                                            <button type='submit' name='delete' value='{ct.OrderNumber}' class='contact-delete' 
                                            formaction='Account.aspx?tab=contact'>Delete</button>
                                        </div>
                                        <button type='submit' class='contact-setdefault button button-gb' name='default' value='{ct.OrderNumber}' 
                                        formaction='Account.aspx?tab=contact'>Set as default</button>")}
                                </div>
                            </div>
                        </div>
                    ";
                }
            }

            return checkEmty == true ? "<p style='color: #888;'>There are no contacts available</p>" : htmls;
        }
    }
}